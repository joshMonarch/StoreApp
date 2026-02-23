namespace Store.Application.DTOs
{
    public class ResponseCategoryDto
    {
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ResponseCategoryDto(
            int id, 
            string? categoryName, 
            DateTime createdAt, 
            DateTime updatedAt) 
        {
            Id = id;
            CategoryName = categoryName;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
