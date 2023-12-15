using Marketer.Interfaces;
using Marketer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Marketer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));

        }

        [HttpPost("register1")]
        public async Task<IActionResult> Register([FromBody] UserRegister userRegister, CancellationToken cancellationToken)
        {
            var response = await _userService.Register(userRegister, cancellationToken);
            return Ok(response);
        }
        [HttpPost("login1")]
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin, CancellationToken cancellationToken)
        {
            if (userLogin is null)
            {
                return BadRequest("Ivalid client request");
            }
            var response = await _userService.Login(userLogin, cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] long id)
        {
            var response = await _userService.GetUser(id);
            return Ok(response);
        }

        [HttpGet("current")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var response = await _userService.GetUser(long.Parse(userId));
            return Ok(response);
        }

    }
}
