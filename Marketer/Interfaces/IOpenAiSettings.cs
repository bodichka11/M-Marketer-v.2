namespace Marketer.Interfaces
{
    public interface IOpenAiSettings
    {
        string GetAnswerPrompt(string question);
    }
}
