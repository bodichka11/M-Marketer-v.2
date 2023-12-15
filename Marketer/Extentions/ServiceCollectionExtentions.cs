using Marketer.Interfaces;
using Marketer.OpenAISettings;
using Marketer.Services;
using OpenAI_API;


namespace Marketer.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void RegisterOpenAI(this IServiceCollection services)
        {
            //services.AddSingleton(e => new OpenAIAPI(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
            services.AddSingleton(e => new OpenAIAPI("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"));
            services.AddScoped<IOpenAiSettings, OpenAiSettings>();
            services.AddScoped<ICompletionService, CompletionService>();
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IChatService, ChatService>();

        }

    }
}
