namespace Marketer.DTO_s
{
    public class InterchangeDto
    {
        public long Id { get; set; }
        public DateTime AnswerDate { get; set; }
        public string? Answer { get; set; }
        public DateTime QuestionDate { get; set; }
        public string Question { get; set; }
    }
}
