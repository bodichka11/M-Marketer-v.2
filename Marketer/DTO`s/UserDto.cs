namespace Marketer.DTO_s
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public ICollection<ChatDto> Chats { get; set; }
    }
}
