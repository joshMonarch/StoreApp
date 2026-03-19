using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Store.Infrastructure.Persistence.ReadModels;

public class AddressReadModel
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public int Id { get; set; }

    [BsonElement("userId")]
    public int UserId { get; set; }
    [BsonElement("locationId")]
    public int LocationId { get; set; }
    [BsonElement("country")]
    public string? Country { get; set; }
    [BsonElement("region")]
    public string? Region { get; set; }
    [BsonElement("city")]
    public string? City { get; set; }
    [BsonElement("name")]
    public string? Name { get; set; }
    [BsonElement("number")]
    public int Number { get; set; }
    [BsonElement("floor")]
    public int Floor { get; set; }
    [BsonElement("door")]
    public string? Door { get; set; }

    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; }

    [BsonElement("updatedAt")]
    public DateTime UpdatedAt { get; set; }

    public AddressReadModel(
        int id, 
        int userId, 
        int locationId, 
        string country, 
        string region, 
        string city, 
        string name, 
        int number, 
        int floor, 
        string door, 
        DateTime createdAt, 
        DateTime updatedAt)
    {
        Id = id;
        UserId = userId;
        LocationId = locationId;
        Country = country;
        Region = region;
        City = city;
        Name = name;
        Number = number;
        Floor = floor;
        Door = door;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}