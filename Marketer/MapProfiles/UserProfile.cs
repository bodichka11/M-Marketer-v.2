using AutoMapper;
using Marketer.DTO_s;
using Marketer.Models;

namespace Marketer.MapProfiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            
        }
    }
}
