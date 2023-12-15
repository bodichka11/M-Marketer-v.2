using AutoMapper;
using Marketer.Data;
using Marketer.DTO_s;
using Marketer.Interfaces;
using Marketer.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Marketer.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        private readonly string _pepper;
        private readonly int _iteration = 3;
        private readonly IMapper _mapper;

        public UserService(DataContext context, ITokenService tokenService, IMapper mapper)
        {
            _context = context;
            _pepper = Environment.GetEnvironmentVariable("PasswordHashExamplePepper");
            _tokenService = tokenService;
            _mapper = mapper;

        }
        public async Task<AuthenticatedResponse> Login(UserLogin userLogin, CancellationToken cancellationToken)
        {
            if (userLogin is null)
                throw new Exception("Invalid client request");

            var user = await _context.Users
             .FirstOrDefaultAsync(x => x.Username == userLogin.Username, cancellationToken);

            if (user == null)
                throw new Exception("Username or password did not match.");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, userLogin.Username),
                new Claim(ClaimTypes.UserData, user.Chats.ToString())
            };
            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);




            var passwordHash = PasswordHasher.ComputeHash(userLogin.Password, user.PasswordSalt, _pepper, _iteration);
            if (user.PasswordHash != passwordHash)
                throw new Exception("Username or password did not match.");

            _context.SaveChanges();

            return new AuthenticatedResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };

        }

        public async Task<RegistredResponse> Register(UserRegister userRegister, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                Username = userRegister.Username,
                Email = userRegister.Email,
                PasswordSalt = PasswordHasher.GenerateSalt()


            };
            user.PasswordHash = PasswordHasher.ComputeHash(userRegister.Password, user.PasswordSalt, _pepper, _iteration);
            await _context.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            
            return new RegistredResponse(user.Id, user.Username, user.Email);
        }

        public async Task<UserDto> GetUser(long id)
        {
            var user = await _context.Users.Where(e => e.Id == id)
                .Include(e => e.Chats)
                .ThenInclude(c => c.Interchanges)
                .FirstOrDefaultAsync();
            

            return _mapper.Map<UserDto>(user);
        }
    }
}
