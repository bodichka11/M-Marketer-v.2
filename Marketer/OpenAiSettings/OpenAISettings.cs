using Marketer.Interfaces;

namespace Marketer.OpenAISettings
{
    public class OpenAiSettings : IOpenAiSettings
    {
        public string GetAnswerPrompt(string question) =>
            $"You are a professional Marketer, as a professional marketer, your goal is to answer questions about marketing and marketing-related questions, the answer should be clear and understandable" +
            $"Question: \n ${question}";
        
    }
}
