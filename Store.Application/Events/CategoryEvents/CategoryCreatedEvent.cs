using Store.Application.Abstractions.Messaging;

namespace Store.Application.Events.CategoryEvents
{
    public class CategoryCreatedEvent: IApplicationEvent
    {
        public int Id { get; init; }
        public string? CategoryName { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }

        public Guid EventId { get; init; }
        public DateTime OccurredAt { get; init; }

        public CategoryCreatedEvent(int id, string? categoryName)
        {
            Id = id;
            CategoryName = categoryName;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            EventId = Guid.NewGuid();
            OccurredAt = DateTime.UtcNow;
        }
    }
}
