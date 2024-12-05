using Azure;
using Azure.AI.OpenAI;

namespace BlogWriterAssistantApp.Services.Assistants;

public partial class AssistantService(IConfiguration configuration) : IAssistantService
{
    private AzureOpenAIClient GetClient()
    {
        return new AzureOpenAIClient(
            new Uri(configuration["AzureOpenAi:Endpoint"]!), 
            new AzureKeyCredential(configuration["AzureOpenAi:Key"]!));
    }
}