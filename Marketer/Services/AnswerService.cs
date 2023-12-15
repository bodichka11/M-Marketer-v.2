using AutoMapper;
using Marketer.Data;
using Marketer.DTO_s;
using Marketer.Interfaces;
using Marketer.Models;
using System.Runtime.CompilerServices;

namespace Marketer.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly DataContext _context;
        private readonly IOpenAiSettings _settings;
        private readonly ICompletionService _completionService;
        private readonly IMapper _mapper;
        public AnswerService(IOpenAiSettings openAiSettings , ICompletionService completionService, DataContext context, IMapper mapper)
        {
            _settings = openAiSettings;
            _completionService = completionService;
            _context = context;
            _mapper = mapper;
        }
        public async Task<InterchangeDto> GetAnswer(AnswerRequestDto requestDto)
        {
            var qdate = DateTime.Now;
            string prompt = _settings.GetAnswerPrompt(requestDto.Question);

            var chatResponse = await _completionService.CreateCompletionAsync(prompt)
                ?? throw new Exception(nameof(AnswerRequestDto));

            string response = chatResponse.ToString();

            if(string.IsNullOrEmpty(response))
            {
                throw new Exception(nameof(AnswerRequestDto));
            }

            string answer = response.ToString();
            var interchange =  new Interchange
            {
                QuestionDate = qdate,
                AnswerDate = DateTime.Now,
                Answer = answer,
                Question = requestDto.Question,
                ChatId = requestDto.ChatId,
            };
            _context.Interchanges.Add(interchange);
            await _context.SaveChangesAsync();


            return _mapper.Map<InterchangeDto>(interchange);


            
        }
    }
}
