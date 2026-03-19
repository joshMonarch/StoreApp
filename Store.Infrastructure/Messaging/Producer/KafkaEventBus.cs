using Confluent.Kafka;
using Store.Application.Abstractions.Messaging;
using Store.Domain.Commons;
using System.Text.Json;

namespace Infrastructure.Kafka.Producer;

public class KafkaEventBus : IEventBus
{
    private readonly IProducer<string, string> _producer;

    public KafkaEventBus(ProducerConfig config)
    {
        _producer = new ProducerBuilder<string, string>(config).Build();
    }

    public async Task PublishAsync(IDomainEvent domainEvent, CancellationToken ct)
    {
        // Derive topic name from event type — e.g. AddressCreatedEvent → addresses.created
        var topic = GetTopic(domainEvent.GetType());
        var payload = JsonSerializer.Serialize(domainEvent, domainEvent.GetType());

        await _producer.ProduceAsync(topic, new Message<string, string>
        {
            Key = domainEvent.EventId.ToString(),
            Value = payload
        }, ct);
    }

    private static string GetTopic(Type eventType)
    {
        // AddressCreatedEvent → addresses.created
        var name = eventType.Name.Replace("Event", string.Empty);

        // Split PascalCase → ["Address", "Created"]
        var parts = System.Text.RegularExpressions.Regex
            .Split(name, @"(?<!^)(?=[A-Z])");

        // ["Address", "Created"] → "addresses.created"
        return $"{parts[0].ToLower()}s.{parts[1].ToLower()}";
    }
}