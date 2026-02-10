namespace Store.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
