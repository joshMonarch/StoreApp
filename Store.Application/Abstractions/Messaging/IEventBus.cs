using Store.Domain.Commons;

namespace Store.Application.Abstractions.Messaging
{
    public interface IEventBus
    {
        Task PublishAsync(IDomainEvent domainEvent, CancellationToken ct);
    }
}
