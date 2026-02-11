using Store.Application.Abstractions.Commons;
using Store.Domain.Entities;

namespace Store.Application.Abstractions
{
    public interface IProductRepository: ICreateRepository<Product>, IReadRepository<Product>, IUpdateRepository<Product>, IDeleteRepository<Product>
    {
    }
}
