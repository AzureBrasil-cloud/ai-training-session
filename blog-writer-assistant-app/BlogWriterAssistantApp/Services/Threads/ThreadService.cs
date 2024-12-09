using Azure;
using Azure.AI.OpenAI;
using BlogWriterAssistantApp.Models;
using BlogWriterAssistantApp.Services.Threads;

namespace BlogWriterAssistantApp.Services.Threads;

public partial class ThreadService(IConfiguration configuration) : IThreadService
{
    private AzureOpenAIClient GetClient()
    {
        return new AzureOpenAIClient(
            new Uri(configuration["AzureOpenAi:Endpoint"]!), 
            new AzureKeyCredential(configuration["AzureOpenAi:Key"]!));
    }
}