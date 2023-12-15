using OpenAI_API.Chat;

namespace Marketer.Interfaces
{
    public interface ICompletionService
    {
        Task<ChatResult> CreateCompletionAsync(string prompt);
    }
}
