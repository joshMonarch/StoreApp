using MediatR;
using Store.Domain.Commons;

namespace Store.Application.MediatRHandlers.Requests.UserRequests
{
    public class CreateUserRequest: IRequest<Result<int>>
    {
        public string? Username { get; }
        public string? Password { get; }
        public string? Email { get; }
        public DateOnly BirthDate { get; }

        public CreateUserRequest(string? username, string? password, string? email, DateOnly birthDate)
        {
            Username = username;
            Password = password;
            Email = email;
            BirthDate = birthDate;
        }
    }
}
