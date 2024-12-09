using BlogWriterAssistantApp.Models;
#pragma warning disable OPENAI001

namespace BlogWriterAssistantApp.Services.Threads;

public partial class ThreadService
{
    public async Task<ThreadResponse> CreateThreadAsync()
    {
        var client = GetClient();
        var assistantClient = client.GetAssistantClient();
        
        var thread = await assistantClient.CreateThreadAsync();

        return new ThreadResponse(thread.Value.Id);
    }
}