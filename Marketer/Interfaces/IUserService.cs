using Marketer.DTO_s;
using Marketer.Models;

namespace Marketer.Interfaces
{
    public interface IUserService
    {
        Task<RegistredResponse> Register(UserRegister userRegister, CancellationToken cancellationToken);
        Task<AuthenticatedResponse> Login(UserLogin userLogin, CancellationToken cancellationToken);
        Task<UserDto> GetUser(long id);
    }
}
