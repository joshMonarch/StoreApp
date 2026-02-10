namespace Store.Domain.Entities
{
    public class Address
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
    }
}
