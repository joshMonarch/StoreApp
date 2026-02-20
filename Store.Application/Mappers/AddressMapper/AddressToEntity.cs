using Store.Application.MediatRHandlers.Requests.AddressRequests;
using Store.Domain.Commons;
using Store.Domain.Entities;

namespace Store.Application.Mappers.AddressMapper
{
    public class AddressToEntity
    {
        public static Result<Address> ToEntity(CreateAddressRequest request)
        {
            return Address.Create(
                request.UserId,
                request.LocationId,
                request.Country,
                request.Region,
                request.City,
                request.Name,
                request.Number,
                request.Floor,
                request.Door
            );
        }
    }
}
