namespace Marketer.Models
{
    public class Interchange : Entity<long>
    {
        public DateTime AnswerDate { get; set; }
        public string? Answer{ get; set; }
        public DateTime QuestionDate { get; set; }
        public string Question { get; set; }
        public long ChatId { get; set; }

        public Chat Chat { get; set; }
    }
}
