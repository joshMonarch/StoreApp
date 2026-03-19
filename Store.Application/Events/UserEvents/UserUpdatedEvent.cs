using MediatR;
using Store.Application.Abstractions.Messaging;

namespace Store.Application.Events.UserEvents
{
    public class UserUpdatedEvent : IApplicationEvent
    {
        public string? Username { get; }
        public string? Password { get; }
        public string? Email { get; }
        public DateOnly BirthDate { get; }
        public Guid EventId { get; init; }
        public DateTime OccurredAt { get; init; }

        public UserUpdatedEvent(string? username, string? password, string? email, DateOnly birthDate)
        {
            Username = username;
            Password = password;
            Email = email;
            BirthDate = birthDate;
            EventId = Guid.NewGuid();
            OccurredAt = DateTime.UtcNow;
        }
    }
}
