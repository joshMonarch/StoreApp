using Confluent.Kafka;
using Confluent.Kafka.Admin;
using Infrastructure.Messaging.Consumer;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Messaging.Coonsumer;

public class KafkaTopicInitializer : IHostedService
{
    private readonly KafkaConsumerConfig _config;
    private readonly ILogger<KafkaTopicInitializer> _logger;

    public KafkaTopicInitializer(
        KafkaConsumerConfig config,
        ILogger<KafkaTopicInitializer> logger)
    {
        _config = config;
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken ct)
    {
        using var adminClient = new AdminClientBuilder(
            new AdminClientConfig { BootstrapServers = _config.BootstrapServers })
            .Build();

        foreach (var topic in _config.Topics)
        {
            try
            {
                await adminClient.CreateTopicsAsync(new[]
                {
                    new TopicSpecification
                    {
                        Name              = topic,
                        NumPartitions     = 3,
                        ReplicationFactor = 1
                    }
                });

                _logger.LogInformation("Topic created: {Topic}", topic);
            }
            catch (CreateTopicsException ex)
                when (ex.Results[0].Error.Code == ErrorCode.TopicAlreadyExists)
            {
                // Topic already exists — nothing to do
                _logger.LogDebug("Topic already exists: {Topic}", topic);
            }
        }
    }

    public Task StopAsync(CancellationToken ct) => Task.CompletedTask;
}