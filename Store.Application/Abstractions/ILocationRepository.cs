using Store.Application.Abstractions.Commons;
using Store.Application.DTOs;
using Store.Application.MediatRHandlers.Requests.LocationRequests;
using Store.Domain.Entities;

namespace Store.Application.Abstractions
{
    public interface ILocationRepository: ICreateRepository<Location>, IReadRepository<ResponseLocationDto, GetLocationsRequest>, IUpdateRepository<Location>, IDeleteRepository<Location>
    {
    }
}
