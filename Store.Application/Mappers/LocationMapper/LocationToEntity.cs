using Store.Application.MediatRHandlers.Requests.LocationRequests;
using Store.Domain.Commons;
using Store.Domain.Entities;

namespace Store.Application.Mappers.LocationMapper
{
    public class LocationToEntity
    {
        public static Result<Location> ToEntity(CreateLocationRequest request)
        {
            return Location.Create(request.LocationType);
        }
    }
}
