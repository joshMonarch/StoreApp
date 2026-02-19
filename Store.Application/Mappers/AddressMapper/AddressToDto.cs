using Store.Application.DTOs;
using Store.Domain.Entities;
using System.Collections.ObjectModel;

namespace Store.Application.Mappers.AddressMapper
{
    public class AddressToDto
    {
        public static ResponseAddressDto ToDto(Address address)
        {
            return new ResponseAddressDto(
                    address.Id,
                    address.UserId,
                    address.LocationId,
                    address.Country,
                    address.Region,
                    address.City,
                    address.Name,
                    address.Number,
                    address.Floor,
                    address.Door,
                    address.CreatedAt,
                    address.UpdatedAt
                );
        }

        public static ReadOnlyCollection<ResponseAddressDto> ToDtoList(ReadOnlyCollection<Address> addresses)
        {
            return addresses.Select(ToDto).ToList().AsReadOnly();
        }
    }
}
