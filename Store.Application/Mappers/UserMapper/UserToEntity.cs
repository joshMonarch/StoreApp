using Store.Application.MediatRHandlers.Requests.UserRequests;
using Store.Domain.Commons;
using Store.Domain.Entities;

namespace Store.Application.Mappers.UserMapper
{
    public class UserToEntity
    {
        public static Result<User> ToEntity(CreateUserRequest request)
        {
            return User.Create(
                    request.Username,
                    request.Password,
                    request.Email,
                    request.BirthDate
                );
        }
    }
}
