using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Store.Infrastructure.Persistence.Mongo.ReadModels
{
    public class LocationReadModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public int Id { get; set; }
        [BsonElement("locationType")]
        public string? LocationType { get; set; }
        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }
        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        public LocationReadModel(
            int id,
            string? locationType,
            DateTime createdAt,
            DateTime updatedAt)
        {
            Id = id;
            LocationType = locationType;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
