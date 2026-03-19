using Store.Domain.Commons;

namespace Store.Domain.Entities
{
    public class Location
    {
        public int Id { get; private set; }
        public string? LocationType { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public List<Address> Addresses { get; private set; } = new List<Address> { };

        public Location(string? locationType)
        {
            LocationType = locationType;
        }

        public static Result<Location> Create(string? locationType)
        {
            if (string.IsNullOrWhiteSpace(locationType))
                return Result<Location>.Fail("Location type not found.");

            if (locationType.Length < 4 || locationType.Length > 30)
                return Result<Location>.Fail("Location type must have 4 to 29 characters.");

            var location = new Location(locationType);

            return Result<Location>.Ok(location);
        }
    }
}
