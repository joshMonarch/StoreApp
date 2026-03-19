using Store.Application.Abstractions.Messaging;

namespace Store.Application.Events.AddressEvents
{
    public class AddressUpdatedEvent : IApplicationEvent
    {
        public int? UserId { get; }
        public int? LocationId { get; }
        public string? Country { get; }
        public string? Region { get; }
        public string? City { get; }
        public string? Name { get; }
        public int? Number { get; }
        public int? Floor { get; }
        public string? Door { get; }

        public Guid EventId { get; init; }
        public DateTime OccurredAt { get; init; }

        public AddressUpdatedEvent(int? userId, int? locationId, string? country, string? region, string? city, string? name, int? number, int? floor, string? door)
        {
            UserId = userId;
            LocationId = locationId;
            Country = country;
            Region = region;
            City = city;
            Name = name;
            Number = number;
            Floor = floor;
            Door = door;
            EventId = Guid.NewGuid();
            OccurredAt = DateTime.UtcNow;
        }
    }
}
