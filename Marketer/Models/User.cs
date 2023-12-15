using System.ComponentModel.DataAnnotations;

namespace Marketer.Models
{
    public class User : Entity<long>
    {
        public string? Username { get; set; }
        public string? PasswordSalt { get; set; }
        public string? PasswordHash { get; set; }
        public string? Email { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public ICollection<Chat> Chats { get; set; } = new List<Chat>();
    }
}
