using Store.Domain.Commons;

namespace Store.Domain.Entities
{
    public class Category
    {
        public int Id { get; private set; }
        public string? CategoryName { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public List<Product> Products { get; private set; } = new List<Product> { };

        public Category(string? categoryName)
        {
            CategoryName = categoryName;
        }

        public static Result<Category> Create(string? categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                return Result<Category>.Fail("Category name cannot be empty.");
            }

            var category = new Category(categoryName);

            return Result<Category>.Ok(category);
        }
    }
}
