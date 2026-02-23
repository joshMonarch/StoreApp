namespace Store.Application.DTOs
{
    public class ResponseLocationDto
    {
        public int Id { get; set; }
        public string? LocationType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ResponseLocationDto(int id, string? locationType, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            LocationType = locationType;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
