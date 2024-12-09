using Azure;
using Azure.AI.OpenAI;
using OpenAI.Chat;

namespace BlogWriterAssistantApp.Services.ChatCompletions;

public class ChatCompletionsService(IConfiguration configuration) : IChatCompletionsService
{
    private AzureOpenAIClient GetClient()
    {
        return new AzureOpenAIClient(
            new Uri(configuration["AzureOpenAi:Endpoint"]!), 
            new AzureKeyCredential(configuration["AzureOpenAi:Key"]!));
    }
    
    public async Task<string> CompleteAsync(string userMessage)
    {
        var client = GetClient();
        var chatClient = client.GetChatClient(configuration["AzureOpenAi:Model"]!);

        var messages = new List<ChatMessage> { new UserChatMessage(userMessage) };

        var completion = await chatClient.CompleteChatAsync(messages.ToArray());

        var result = completion.Value.Content[0].Text;

        return result;
    }
}