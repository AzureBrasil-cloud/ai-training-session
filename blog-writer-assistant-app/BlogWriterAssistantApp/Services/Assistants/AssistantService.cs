using Azure;
using Azure.AI.OpenAI;
using BlogWriterAssistantApp.Services.ToolHandler;
using OpenAI.Assistants;

#pragma warning disable OPENAI001

namespace BlogWriterAssistantApp.Services.Assistants;

public partial class AssistantService(IConfiguration configuration, IToolHandler toolHandler) : IAssistantService
{
    private AzureOpenAIClient GetClient()
    {
        return new AzureOpenAIClient(
            new Uri(configuration["AzureOpenAi:Endpoint"]!), 
            new AzureKeyCredential(configuration["AzureOpenAi:Key"]!));
    }
    
    private decimal CalculateTokenUsageCost(RunTokenUsage usage)
    {
        var inputPrice = configuration.GetValue<decimal>("AzureOpenAi:InputPrice"); // 1M tokens
        var outputPrice = configuration.GetValue<decimal>("AzureOpenAi:OutputPrice"); // 1M tokens

        var inputTokensCost =  usage.InputTokenCount * (inputPrice)/1_000_000;
        var outputTokensCost = usage.OutputTokenCount * (outputPrice)/1_000_000;
        
        return  inputTokensCost + outputTokensCost;
    }
}