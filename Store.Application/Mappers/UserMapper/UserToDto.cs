using Store.Application.DTOs;
using Store.Domain.Entities;
using System.Collections.ObjectModel;

namespace Store.Application.Mappers.UserMapper
{
    public class UserToDto
    {
        public static ResponseUserDto ToDto(User user)
        {
            return new ResponseUserDto(
                    user.Id,
                    user.Username,
                    user.Email,
                    user.Password,
                    user.BirthDate,
                    user.CreatedAt,
                    user.UpdatedAt
                );
        }

        public static ReadOnlyCollection<ResponseUserDto> ToDtoList(ReadOnlyCollection<User> users)
        {
            return users.Select(ToDto).ToList().AsReadOnly();
        }
    }
}
