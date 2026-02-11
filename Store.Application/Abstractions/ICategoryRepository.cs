using Store.Application.Abstractions.Commons;
using Store.Domain.Entities;

namespace Store.Application.Abstractions
{
    public interface ICategoryRepository: ICreateRepository<Category>, IReadRepository<Category>, IUpdateRepository<Category>, IDeleteRepository<Category>
    {
    }
}
