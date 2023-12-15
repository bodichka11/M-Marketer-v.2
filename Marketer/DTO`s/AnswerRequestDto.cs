namespace Marketer.DTO_s
{
    public class AnswerRequestDto
    {
        public string Question { get; set; }

        public long ChatId { get; set; }

        public AnswerRequestDto(string question)
        {
            Question = question;
        }
    }
}
