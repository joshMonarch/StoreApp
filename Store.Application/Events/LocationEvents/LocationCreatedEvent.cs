using MediatR;
using Store.Application.Abstractions.Messaging;

namespace Store.Application.Events.LocationEvents
{
    public class LocationCreatedEvent: IApplicationEvent
    {
        public int Id { get; init; }
        public string? LocationType { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
        public Guid EventId { get; init; }
        public DateTime OccurredAt { get; init; }

        public LocationCreatedEvent(int id, string? locationType)
        {
            Id = id;
            LocationType = locationType;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            EventId = Guid.NewGuid();
            OccurredAt = DateTime.UtcNow;
        }
    }
}
