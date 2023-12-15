using Marketer.Models;

namespace Marketer.DTO_s
{
    public class ChatDto
    {
        public DateTime CreationDate { get; set; }
        public long Id { get; set; }
        public ICollection<InterchangeDto> Interchanges { get; set; }
    }
}
