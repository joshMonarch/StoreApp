using MediatR;
using Store.Application.Abstractions.Messaging;

namespace Store.Application.Events.UserEvents
{
    public class UserCreatedEvent: IApplicationEvent
    {
        public int Id { get; init; }
        public string? Username { get; init; }
        public string? Password { get; init; }
        public string? Email { get; init; }
        public DateOnly BirthDate { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
        public Guid EventId { get; init; }
        public DateTime OccurredAt { get; init; }

        public UserCreatedEvent(int id, string? username, string? password, string? email, DateOnly birthDate)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
            BirthDate = birthDate;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            EventId = Guid.NewGuid();
            OccurredAt = DateTime.UtcNow;
        }
    }
}
