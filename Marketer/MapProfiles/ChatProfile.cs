using AutoMapper;
using Marketer.DTO_s;
using Marketer.Models;

namespace Marketer.MapProfiles
{
    public class ChatProfile: Profile
    {
        public ChatProfile() 
        {
            CreateMap<CreateChatDto, Chat>();
            CreateMap<Chat, ChatDto>();
        }
    }
}
