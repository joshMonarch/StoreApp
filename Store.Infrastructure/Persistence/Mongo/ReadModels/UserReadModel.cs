using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Store.Infrastructure.Persistence.Mongo.ReadModels
{
    public class UserReadModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public int Id { get; set; }
        [BsonElement("username")]
        public string? Username { get; set; }
        [BsonElement("password")]
        public string? Password { get; set; }
        [BsonElement("email")]
        public string? Email { get; set; }
        [BsonElement("birthDate")]
        public DateOnly BirthDate { get; set; }
        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }
        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        public UserReadModel(
            int id,
            string? username,
            string? password,
            string? email,
            DateOnly birthDate,
            DateTime createdAt,
            DateTime updatedAt)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
            BirthDate = birthDate;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
