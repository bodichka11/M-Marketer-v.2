using Marketer.DTO_s;
using Marketer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Marketer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpPost]
        public async Task<IActionResult> GetAnswerAsync(AnswerRequestDto requestDto)
        {
            var response = await _answerService.GetAnswer(requestDto);
            return Ok(response);    
        }
    }
}
