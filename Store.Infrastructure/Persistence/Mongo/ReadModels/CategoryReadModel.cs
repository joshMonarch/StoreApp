using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Store.Infrastructure.Persistence.Mongo.ReadModels
{
    public class CategoryReadModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public int Id { get; set; }
        [BsonElement("categoryName")]
        public string? CategoryName { get; set; }
        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }
        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        public CategoryReadModel(
            int id,
            string categoryName,
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
