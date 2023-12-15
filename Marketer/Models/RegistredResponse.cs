namespace Marketer.Models
{
    public class RegistredResponse
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public RegistredResponse(long id, string username, string email)
        {
            Id = id;
            Username = username;
            Email = email;
            
        }
    }
}
