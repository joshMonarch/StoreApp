namespace Infrastructure.Messaging.Consumer;

public class KafkaConsumerConfig
{
    public const string Section = "Kafka:Consumer";

    public string BootstrapServers { get; init; } = string.Empty;

    /// <summary>
    /// The GroupId is used to group consumers.
    /// If several share it, Kafka distributes messages between them.
    /// If you use a different one, this consumer receives all messages.
    /// </summary>
    public string GroupId { get; init; } = string.Empty;

    /// <summary>
    /// Topics this consumer subscribes to.
    /// Ex: ["addresses.created", "addresses.updated"]
    /// </summary>
    public List<string> Topics { get; init; } = [];

    /// <summary>
    /// If the GroupId is new:
    /// earliest = reads all messages from the beginning
    /// latest = only new messages from now on
    /// </summary>
    public string AutoOffsetReset { get; init; } = "earliest";

    /// <summary>
    /// false = offset is confirmed manually
    /// after the message is processed successfully.
    /// This avoids losing messages if something fails.
    /// </summary>
    public bool EnableAutoCommit { get; init; } = false;

    /// <summary>
    /// Time to wait for messages on each poll
    /// before continuing the loop.
    /// </summary>
    public int ConsumeTimeoutMs { get; init; } = 5000;
}