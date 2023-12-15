namespace Marketer.Models
{
    public class Chat: Entity<long>
    {
        public DateTime CreationDate { get; set; }
        public ICollection<Interchange> Interchanges { get; set; } = new List<Interchange>();
        public long UserId { get; set; }

        public User User { get; set; }
    }
}
