using MediatR;
using Store.Application.Abstractions.Messaging;

namespace Store.Application.Events.AddressEvents
{
    public class AddressCreatedEvent : IApplicationEvent
    {
        public int Id { get; init; }
        public int UserId { get; init; }
        public int LocationId { get; init; }
        public string? Country { get; init; }
        public string? Region { get; init; }
        public string? City { get; init; }
        public string? Name { get; init; }
        public int Number { get; init; }
        public int Floor { get; init; }
        public string? Door { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }

        public Guid EventId { get; init; }
        public DateTime OccurredAt { get; init; }
        public AddressCreatedEvent(
            int id,
            int userId,
            int locationId,
            string? country,
            string? region,
            string? city,
            string? name,
            int number,
            int floor,
            string? door)
        {
            Id = id;
            UserId = userId;
            LocationId = locationId;
            Country = country;
            Region = region;
            City = city;
            Name = name;
            Number = number;
            Floor = floor;
            Door = door;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            EventId = Guid.NewGuid();
            OccurredAt = DateTime.UtcNow;
        }
    }

}
