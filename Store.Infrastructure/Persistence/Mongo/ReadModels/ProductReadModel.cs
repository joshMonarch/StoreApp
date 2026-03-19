using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Store.Infrastructure.Persistence.Mongo.ReadModels
{
    public class ProductReadModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public int Id { get; set; }
        [BsonElement("userId")]
        public int? UserId { get; set; }
        [BsonElement("categoryId")]
        public int? CategoryId { get; set; }
        [BsonElement("name")]
        public string? Name { get; set; }
        [BsonElement("stock")]
        public int? Stock { get; set; }
        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }
        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        public ProductReadModel(
            int id,
            int? userId,
            int? categoryId,
            string? name,
            int? stock,
            DateTime createdAt,
            DateTime updatedAt)
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
