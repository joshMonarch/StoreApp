
using MediatR;
using Store.Application.Abstractions.Messaging;

namespace Store.Application.Events.CategoryEvents
{
    public class CategoryUpdatedEvent : IApplicationEvent
    {
        public string? CategoryName { get; }
        public Guid EventId { get; init; }
        public DateTime OccurredAt { get; init; }
        public CategoryUpdatedEvent(string? categoryName)
        {
            CategoryName = categoryName;
            EventId = Guid.NewGuid();
            OccurredAt = DateTime.UtcNow;
        }
    }
}
