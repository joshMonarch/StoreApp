using Confluent.Kafka;
using Infrastructure.Messaging.Consumer;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Store.Application.Events.AddressEvents;
using Store.Application.Events.CategoryEvents;
using Store.Application.Events.LocationEvents;
using Store.Application.Events.ProductEvents;
using Store.Application.Events.UserEvents;
using System.Text.Json;

namespace Infrastructure.Kafka.Consumer;

public class KafkaConsumerService : BackgroundService
{
    private readonly IConsumer<string, string> _consumer;
    private readonly KafkaConsumerConfig _config;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<KafkaConsumerService> _logger;

    // Registry: topic → event type
    // Add new events here without touching any other logic
    private static readonly Dictionary<string, Type> _topicRegistry = new()
    {
        ["addresses.created"] = typeof(AddressCreatedEvent),
        ["addresses.updated"] = typeof(AddressUpdatedEvent),
        ["users.created"] = typeof(UserCreatedEvent),
        ["users.updated"] = typeof(UserUpdatedEvent),
        ["products.created"] = typeof(ProductCreatedEvent),
        ["products.updated"] = typeof(ProductUpdatedEvent),
        ["categories.created"] = typeof(CategoryCreatedEvent),
        ["categories.updated"] = typeof(CategoryUpdatedEvent),
        ["locations.created"] = typeof(LocationCreatedEvent),
        ["locations.updated"] = typeof(LocationUpdatedEvent),
    };

    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public KafkaConsumerService(
        ConsumerConfig consumerConfig,
        KafkaConsumerConfig config,
        IServiceScopeFactory scopeFactory,
        ILogger<KafkaConsumerService> logger)
    {
        _config = config;
        _scopeFactory = scopeFactory;
        _logger = logger;

        _consumer = new ConsumerBuilder<string, string>(consumerConfig)
            .SetErrorHandler((_, e) =>
                _logger.LogError("Kafka error: {Reason}", e.Reason))
            .Build();
    }

    protected override async Task ExecuteAsync(CancellationToken ct)
    {

        await WaitForTopicsAsync(ct);
        _consumer.Subscribe(_config.Topics);

        _logger.LogInformation(
            "KafkaConsumerService listening on topics: {Topics}",
            string.Join(", ", _config.Topics));

        while (!ct.IsCancellationRequested)
        {
            try
            {
                var result = _consumer.Consume(
                    TimeSpan.FromMilliseconds(_config.ConsumeTimeoutMs));

                if (result is null) continue;

                _logger.LogInformation(
                    "Message received — Topic: {Topic} | Key: {Key} | Offset: {Offset}",
                    result.Topic, result.Message.Key, result.Offset);

                await DispatchAsync(result.Topic, result.Message.Value, ct);

                _consumer.Commit(result);
            }
            catch (ConsumeException ex)
            {
                _logger.LogError(ex, "Consume error: {Reason}", ex.Error.Reason);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled error processing Kafka message");
                // No commit → Kafka will redeliver the message
            }
        }
    }

    private async Task DispatchAsync(string topic, string payload, CancellationToken ct)
    {
        if (!_topicRegistry.TryGetValue(topic, out var eventType))
        {
            _logger.LogWarning("No event type registered for topic: {Topic}", topic);
            return;
        }

        var notification = JsonSerializer.Deserialize(payload, eventType, _jsonOptions) as INotification;

        if (notification is null)
        {
            _logger.LogWarning("Failed to deserialize payload for topic: {Topic}", topic);
            return;
        }

        await using var scope = _scopeFactory.CreateAsyncScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

        await mediator.Publish(notification, ct);
    }

    private async Task WaitForTopicsAsync(CancellationToken ct)
    {
        using var adminClient = new AdminClientBuilder(
            new AdminClientConfig { BootstrapServers = _config.BootstrapServers })
            .Build();

        var maxRetries = 10;

        for (int attempt = 1; attempt <= maxRetries; attempt++)
        {
            try
            {
                var metadata = adminClient.GetMetadata(TimeSpan.FromSeconds(5));
                var existingTopics = metadata.Topics.Select(t => t.Topic).ToHashSet();
                var missing = _config.Topics.Except(existingTopics).ToList();

                if (!missing.Any())
                {
                    _logger.LogInformation("All topics available, starting consumer.");
                    return;
                }

                _logger.LogWarning(
                    "Waiting for topics ({Attempt}/{Max}): {Missing}",
                    attempt, maxRetries, string.Join(", ", missing));
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Could not fetch metadata, retrying...");
            }

            await Task.Delay(2000, ct);
        }

        _logger.LogError("Topics not available after {Max} retries.", maxRetries);
    }

    public override void Dispose()
    {
        _consumer.Close();
        _consumer.Dispose();
        base.Dispose();
    }
}