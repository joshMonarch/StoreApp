using Store.Application.Abstractions.Commons;
using Store.Domain.Entities;

namespace Store.Application.Abstractions
{
    public interface ILocationRepository: ICreateRepository<Location>, IReadRepository<Location>, IUpdateRepository<Location>, IDeleteRepository<Location>
    {
    }
}
