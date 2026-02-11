using Store.Application.Abstractions.Commons;
using Store.Domain.Entities;

namespace Store.Application.Abstractions
{
    public interface IAddressRepository: ICreateRepository<Address>, IReadRepository<Address>, IUpdateRepository<Address>, IDeleteRepository<Address>
    {
    }
}
