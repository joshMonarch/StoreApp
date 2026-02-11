using Store.Application.Abstractions.Commons;
using Store.Domain.Entities;

namespace Store.Application.Abstractions
{
    public interface IUserRepository: ICreateRepository<User>, IReadRepository<User>, IUpdateRepository<User>, IDeleteRepository<User>
    {
    }
}
