using BlogWriterAssistantApp.Models;
using BlogWriterAssistantApp.Tools;
using OpenAI.Assistants;
#pragma warning disable OPENAI001

namespace BlogWriterAssistantApp.Services.Assistants;

public partial class AssistantService
{
    public async Task<AssistantResponse> CreateAssistantAsync(CreateAssistantRequest request)
    {
        var client = GetClient();
        var assistantClient = client.GetAssistantClient();
        
        var assistantOptions = new AssistantCreationOptions
        {
            Name = request.Name,
            Instructions = request.Description,
            ToolResources = new ToolResources(),
            Tools =
            {
                EmailTool.Definition,
                BlogArticleWriterTool.Definition
            },
        };

        Assistant assistant = await assistantClient.CreateAssistantAsync(configuration["AzureOpenAi:Model"]!, assistantOptions);

        return new AssistantResponse(
            assistant.Id, 
            assistant.Name,
            assistant.Instructions);
    }
}