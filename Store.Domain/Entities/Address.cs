using Store.Domain.Commons;

namespace Store.Domain.Entities
{
    public class Address
    {
        public int Id { get; private set; }
        public int? UserId { get; private set; }
        public int? LocationId { get; private set; }
        public string? Country { get; private set; }
        public string? Region { get; private set; }
        public string? City { get; private set; }
        public string? Name { get; private set; }
        public int? Number { get; private set; }
        public int? Floor { get; private set; }
        public string? Door { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public Address(int? userId, int? locationId, string? country, string? region, string? city, string? name, int? number, int? floor, string? door)
        {
            UserId = userId;
            LocationId = locationId;
            Country = country;
            Region = region;
            City = city;
            Name = name;
            Number = number;
            Floor = floor;
            Door = door;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public static Result<Address> Create(int? userId, int? locationId, string? country, string? region, string? city, string? name, int? number, int? floor, string? door)
        {
            if (userId <= 0)
                return Result<Address>.Fail("UserId must be higher than 0.");

            if (locationId <= 0)
                return Result<Address>.Fail("LocationId must be higher than 0.");

            if (string.IsNullOrWhiteSpace(country))
                return Result<Address>.Fail("Country not found.");

            if (country.Length < 4 || country.Length > 30)
                return Result<Address>.Fail("Country must have 4 to 29 characters.");

            if (string.IsNullOrWhiteSpace(region))
                return Result<Address>.Fail("Region not found.");

            if (region.Length < 4 || region.Length > 30)
                return Result<Address>.Fail("Region must have 4 to 29 characters.");

            if (string.IsNullOrWhiteSpace(city))
                return Result<Address>.Fail("City not found.");

            if (city.Length < 4 || city.Length > 30)
                return Result<Address>.Fail("City must have 4 to 29 characters.");

            if (string.IsNullOrWhiteSpace(name))
                return Result<Address>.Fail("Name not found.");

            if (name.Length < 4 || name.Length > 30)
                return Result<Address>.Fail("Name must have 4 to 29 characters.");

            if (number <= 0)
                return Result<Address>.Fail("Number must be higher than 0.");

            if (floor < 0)
                return Result<Address>.Fail("Floor must be a positive number.");

            if (string.IsNullOrWhiteSpace(door))
                return Result<Address>.Fail("Door not found.");

            if (door.Length > 1)
                return Result<Address>.Fail("Door must have only 1 character.");

            if (door[0] < 'A' || door[0] > 'Z')
                return Result<Address>.Fail("Door must have A-Z letters.");

            Address address = new Address(
                    userId,
                    locationId,
                    country,
                    region,
                    city,
                    name,
                    number,
                    floor,
                    door
                );

            return Result<Address>.Ok(address);
        }
    }
}
