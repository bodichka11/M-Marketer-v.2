using Marketer.DTO_s;
using Marketer.Models;

namespace Marketer.Interfaces
{
    public interface IChatService
    {
        Task<ChatDto> CreateChat(CreateChatDto createChatDto);
        Task<bool> DeleteChat(long chatId);
        Task<ChatDto> GetChat(long id);
    }
}
