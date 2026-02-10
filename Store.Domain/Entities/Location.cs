namespace Store.Domain.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string? LocationType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address> { };
    }
}
