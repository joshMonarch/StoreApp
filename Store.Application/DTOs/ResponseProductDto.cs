namespace Store.Application.DTOs
{
    public class ResponseProductDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? CategoryId { get; set; }
        public string? Name { get; set; }
        public int? Stock { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public ResponseProductDto(int id, int? userId, int? categoryId, string? name, int? stock, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            UserId = userId;
            CategoryId = categoryId;
            Name = name;
            Stock = stock;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
