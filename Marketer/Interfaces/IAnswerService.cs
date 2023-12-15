using Marketer.DTO_s;
using Marketer.Models;

namespace Marketer.Interfaces
{
    public interface IAnswerService
    {
        Task<InterchangeDto> GetAnswer(AnswerRequestDto requestDto);
    }
}
