using Store.Application.DTOs;
using Store.Domain.Entities;
using System.Collections.ObjectModel;

namespace Store.Application.Mappers.LocationMapper
{
    public class LocationToDto
    {
        public static ResponseLocationDto ToDto(Location location)
        {
            return new ResponseLocationDto(
                location.Id,
                location.LocationType,
                location.CreatedAt,
                location.UpdatedAt
            );
        }

        public static ReadOnlyCollection<ResponseLocationDto> ToDtoList(ReadOnlyCollection<Location> locations)
        {
            return locations.Select(ToDto).ToList().AsReadOnly();
        }
    }
}
