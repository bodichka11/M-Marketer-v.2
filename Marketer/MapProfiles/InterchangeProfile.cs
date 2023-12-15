using AutoMapper;
using Marketer.DTO_s;
using Marketer.Models;

namespace Marketer.MapProfiles
{
    public class InterchangeProfile: Profile
    {
        public InterchangeProfile()
        {
            CreateMap<Interchange, InterchangeDto>();
            
        }
    }
}
