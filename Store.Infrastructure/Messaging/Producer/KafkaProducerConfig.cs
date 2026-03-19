namespace Infrastructure.Messaging.Producer;

public class KafkaProducerConfig
{
    public const string Section = "Kafka:Producer";

    public string BootstrapServers { get; init; } = string.Empty;

    /// <summary>
    /// all → waits for all replica brokers to confirm (safer, slower)
    /// 1   → only the leader confirms (balanced)
    /// 0   → no confirmation (faster, may lose messages)
    /// </summary>
    public string Acks { get; init; } = "all";

    /// <summary>
    /// Automatic retries if the broker does not respond.
    /// </summary>
    public int Retries { get; init; } = 3;

    /// <summary>
    /// Time in ms between retries.
    /// </summary>
    public int RetryBackoffMs { get; init; } = 1000;

    /// <summary>
    /// Max time in ms the producer waits to batch messages
    /// before sending. 0 = send immediately.
    /// </summary>
    public int LingerMs { get; init; } = 5;

    /// <summary>
    /// Enables idempotence to avoid duplicates
    /// even if retries happen. Requires Acks = "all".
    /// </summary>
    public bool EnableIdempotence { get; init; } = true;
}