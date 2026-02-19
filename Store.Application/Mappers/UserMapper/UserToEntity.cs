using Store.Domain.Entities;

namespace Store.Application.Mappers.UserMapper
{
    public class UserToEntity
    {
        public static User ToEntity(CreateUserCommand command)
        {
            return User.Create(
                    command.username,
                    command.password,
                    command.email,
                    command.birthDate
                );
        }
    }
}
