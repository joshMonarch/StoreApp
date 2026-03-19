using MediatR;
using Store.Application.Abstractions.Messaging;

namespace Store.Application.Events.ProductEvents
{
    public class ProductCreatedEvent: IApplicationEvent
    {
        public int Id { get; init; }
        public int? UserId { get; init; }
        public int? CategoryId { get; init; }
        public string? Name { get; init; }
        public int Stock { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
        public Guid EventId { get; init; }
        public DateTime OccurredAt { get; init; }

        public ProductCreatedEvent(int id, int? userId, int? categoryId, string? name, int stock)
        {
            Id = id;
            UserId = userId;
            CategoryId = categoryId;
            Name = name;
            Stock = stock;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            EventId = Guid.NewGuid();
            OccurredAt = DateTime.UtcNow;
        }

    }
}
