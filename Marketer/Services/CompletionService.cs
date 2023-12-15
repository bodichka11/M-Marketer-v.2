using Marketer.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;
using System.Globalization;

namespace Marketer.Services
{
    public class CompletionService : ICompletionService
    {
        private readonly OpenAIAPI _openAiApi;
        private readonly IConfiguration _configuration;


        public CompletionService(OpenAIAPI api, IConfiguration configuration)
        {
            _openAiApi = api;
            _configuration = configuration;
        }
        public async Task<ChatResult> CreateCompletionAsync(string prompt)
        {
            var request = new ChatRequest()
            {
                Model = Model.ChatGPTTurbo,
                MaxTokens = int.Parse(_configuration["OpenAPISettings:MaxTokens"]),
                Temperature = double.Parse(_configuration["OpenAPISettings:Temperature"], CultureInfo.InvariantCulture),
                PresencePenalty = double.Parse(_configuration["OpenAPISettings:PresencePenalty"], CultureInfo.InvariantCulture),
                FrequencyPenalty = double.Parse(_configuration["OpenAPISettings:FrequencyPenalty"], CultureInfo.InvariantCulture),
                Messages = new ChatMessage[]
                {
                    new ChatMessage(ChatMessageRole.User, prompt)
                }
            };

            return await _openAiApi.Chat.CreateChatCompletionAsync(request);
        }
    }
}
