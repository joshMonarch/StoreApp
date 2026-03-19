using MediatR;
using Store.Application.Abstractions.Messaging;

namespace Store.Application.Events.ProductEvents
{
    public class ProductUpdatedEvent : IApplicationEvent
    {
        public int UserId { get; }
        public int CategoryId { get; }
        public string? Name { get; }
        public int? Stock { get; }
        public Guid EventId { get; init; }
        public DateTime OccurredAt { get; init; }

        public ProductUpdatedEvent(int userId, int categoryId, string? name, int stock)
        {
            UserId = userId;
            CategoryId = categoryId;
            Name = name;
            Stock = stock;
            EventId = Guid.NewGuid();
            OccurredAt = DateTime.UtcNow;
        }
    }
}
