using AutoMapper;
using Marketer.Data;
using Marketer.DTO_s;
using Marketer.Interfaces;
using Marketer.Models;
using Microsoft.EntityFrameworkCore;

namespace Marketer.Services
{
    public class ChatService : IChatService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ChatService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ChatDto> CreateChat(CreateChatDto createChatDto)
        {
            Chat chat = _mapper.Map<Chat>(createChatDto);

            _context.Chats.Add(chat);
            await _context.SaveChangesAsync();

            return _mapper.Map<ChatDto>(chat);
        }

        public async Task<bool> DeleteChat(long chatId)
        {
            var chat = await _context.Chats.FirstOrDefaultAsync(c => c.Id == chatId);
            if (chat == null)
            {
                return false;
            }

            _context.Chats.Remove(chat);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<ChatDto> GetChat(long id)
        {
            var chat = await _context.Chats.Where(c => c.Id == id)
                .Include(c => c.Interchanges)
                .FirstOrDefaultAsync();
            return _mapper.Map<ChatDto>(chat);
        }

    }
}
