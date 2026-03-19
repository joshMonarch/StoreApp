using MediatR;
using Store.Application.Abstractions.Messaging;

namespace Store.Application.Events.LocationEvents
{
    public class LocationUpdatedEvent : IApplicationEvent
    {
        public string? LocationType { get; }
        public Guid EventId { get; init; }
        public DateTime OccurredAt { get; init; }
        public LocationUpdatedEvent(string? locationType)
        {
            LocationType = locationType;
            EventId = Guid.NewGuid();
            OccurredAt = DateTime.UtcNow;
        }
    }
}
