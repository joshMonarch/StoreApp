namespace Store.Domain.Commons;

public interface IDomainEvent
{
    Guid EventId { get; }
    DateTime OccurredAt { get; }
}