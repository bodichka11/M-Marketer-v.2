using Marketer.DTO_s;
using Marketer.Interfaces;
using Marketer.Models;
using Marketer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Marketer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost]
        public async Task<ActionResult<ChatDto>> CreateChat(CreateChatDto createChatDto)
        {
            var chat = await _chatService.CreateChat(createChatDto);

            return Ok(chat);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteChat(long id)
        {
            var chat = await _chatService.DeleteChat(id);
            if (chat) return NoContent();
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetChat([FromRoute] long id)
        {
            var response = _chatService.GetChat(id);
            return Ok(response);
        }



    }
}
