namespace Store.Application.DTOs
{
    public class ResponseUserDto
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ResponseUserDto(int id, string? username, string? password, string? email, DateOnly birthDate, DateTime createdAt, DateTime updatedAt)
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
