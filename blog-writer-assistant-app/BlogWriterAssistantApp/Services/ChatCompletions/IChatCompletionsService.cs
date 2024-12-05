namespace BlogWriterAssistantApp.Services.ChatCompletions;

public interface IChatCompletionsService
{
    public Task<string> CompleteAsync(string userMessage);
}