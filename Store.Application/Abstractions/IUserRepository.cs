using Store.Application.Abstractions.Commons;
using Store.Application.DTOs;
using Store.Application.MediatRHandlers.Requests.UserRequests;
using Store.Domain.Entities;

namespace Store.Application.Abstractions
{
    public interface IUserRepository: ICreateRepository<User>, IReadRepository<ResponseUserDto, GetUsersRequest>, IUpdateRepository<User>, IDeleteRepository<User>
    {
    }
}
