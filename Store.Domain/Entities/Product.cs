using Store.Domain.Commons;

namespace Store.Domain.Entities
{
    public class Product
    {
        public int Id { get; private set; }
        public int? UserId { get; private set; }
        public int? CategoryId { get; private set; }
        public string? Name { get; private set; }
        public int? Stock { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private Product() { }
        public Product(int? userId, int? categoryId, string? name, int? stock)
        {
            UserId = userId;
            CategoryId = categoryId;
            Name = name;
            Stock = stock;
        }

        public static Result<Product> Create(int? userId, int? categoryId, string? name, int? stock)
        {
            if (userId <= 0)
                return Result<Product>.Fail("UserId must be higher than 0.");
            if (categoryId <= 0)
                return Result<Product>.Fail("CategoryId must be higher than 0.");
            if (string.IsNullOrWhiteSpace(name) || name.Trim().Length < 5)
                return Result<Product>.Fail("Name must have 5 characters at least.");
            if (stock < 0)
                return Result<Product>.Fail("Stock must be a positive number.");

            var product = new Product(
                    userId,
                    categoryId,
                    name,
                    stock
                );

            return Result<Product>.Ok(product);
        }
    }
}
