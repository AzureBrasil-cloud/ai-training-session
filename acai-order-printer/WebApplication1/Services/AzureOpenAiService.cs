using System.Diagnostics.CodeAnalysis;
using Azure;
using Azure.AI.OpenAI;
using OpenAI.Assistants;
using WebApplication1.Extensions;

namespace WebApplication1.Services;

public class AzureOpenAiService(IConfiguration configuration)
{
    private readonly AzureOpenAIClient _aiClient = new(new(configuration["AzureOpenAi:Endpoint"]), new AzureKeyCredential(configuration["AzureOpenAi:Key"]));

    [Experimental("OPENAI001")]
    public async Task<string> AnalyzeAcaiOrder(string documentIntelligenceResponse)
    {
        var assistantClient = _aiClient.GetAssistantClient();

        var threadOptions = new ThreadCreationOptions
        {
            InitialMessages = { documentIntelligenceResponse }
        };
        ThreadRun run = await assistantClient.CreateThreadAndRunAsync(configuration["AzureOpenAi:AssistantId"],
            threadOptions);

        do
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            run = await assistantClient.GetRunAsync(run.ThreadId, run.Id);
        } while (!run.Status.IsTerminal);

        var messages = assistantClient.GetMessagesAsync(run.ThreadId, new MessageCollectionOptions
        {
            Order = MessageCollectionOrder.Ascending
        });

        var message = await messages.GetLastAsync();
        return message.Content.First()?.Text;
    }
}