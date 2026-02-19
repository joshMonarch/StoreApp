namespace Store.Application.DTOs
{
    public class ResponseAddressDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? City { get; set; }
        public string? Name { get; set; }
        public int Number { get; set; }
        public int? Floor { get; set; }
        public string? Door { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public ResponseAddressDto(
            int id, 
            int userId, 
            int locationId, 
            string? country, 
            string? region, 
            string? city, 
            string? name, 
            int number, 
            int? floor, 
            string? door, 
            DateTime createdAt, 
            DateTime updatedAt) 
        {
            Id = id;
            UserId = userId;
            LocationId = locationId;
            Country = country;
            Region = region;
            City = city;
            Name = name;
            Number = number;
            Floor = floor;
            Door = door;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
