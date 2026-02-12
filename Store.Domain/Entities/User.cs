using Store.Domain.Commons;

namespace Store.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string? Username { get; private set; }
        public string? Password { get; private set; }
        public string? Email { get; private set; }
        public DateOnly BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public List<Address> Addresses { get; private set; } = new List<Address> { };
        public List<Product> Products { get; private set; } = new List<Product> { };

        public User(string username, string password, string email, DateOnly birthDate)
        {
            Username = username;
            Password = password;
            Email = email;
            BirthDate = birthDate;
        }
        public static Result<User> Create(string username, string password, string email, DateOnly birthDate)
        {
            if (string.IsNullOrWhiteSpace(username) || username.Trim().Length < 3)
                return Result<User>.Fail("Name must have 3 characters at least.");

            if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
                return Result<User>.Fail("Email not valid");

            if (string.IsNullOrWhiteSpace(password) || password.Trim().Length < 8)
                return Result<User>.Fail("Password must have 8 charaters at least.");

            var age = GetAge(birthDate);
            if (age < 18)
                return Result<User>.Fail("Age must be 18 or older.");

            var user = new User
            (
                username.Trim(),
                password.Trim(), 
                email.Trim().ToLowerInvariant(), 
                birthDate
            );

            return Result<User>.Ok(user);
        }

        private static int GetAge(DateOnly birthDate)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.UtcNow);
            var age = today.Year - birthDate.Year;
            if (today < birthDate.AddYears(age)) age--;
            return age;
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email.Trim();
            }
            catch
            {
                return false;
            }
        }
    }
}
