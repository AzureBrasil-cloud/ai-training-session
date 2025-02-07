#pragma warning disable OPENAI001
using Azure;
using Azure.AI.OpenAI;
using DocAssistantApp;
using Microsoft.Extensions.Configuration;
using MultiLanguageAsssistant;
using OpenAI.Chat;

var builder = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

IConfiguration config = builder.Build();

var client = GetClient();
var chatClient = GetChatClient();

CliInterface.WritePanel();

var chatHistory = new List<ChatMessage> { new SystemChatMessage(Constants.SystemMessage) };
    
while (true)
{
    var request = CliInterface.ReadConsole();

    if (string.Compare(request, "exit", StringComparison.OrdinalIgnoreCase) == 0)
    {
        break;
    }

    var userMessage = new UserChatMessage(request);
    chatHistory.Add(userMessage);
    
    ChatCompletion completion = chatClient.CompleteChat(chatHistory);
            
    foreach (var contentItem in completion!.Content)
    {
        if (!string.IsNullOrEmpty(contentItem.Text))
        {
            var text = contentItem.Text;
            
            CliInterface.WriteLine($"{text}");
        }
    } 
    
    CliInterface.WriteLine($"\U0001F4B0 Output tokens: {completion.Usage.OutputTokenCount}");
    CliInterface.WriteLine($"\U0001F4B0 Input tokens: {completion.Usage.InputTokenCount}");
    CliInterface.WriteLine($"\U0001F4B0 Total de tokens: {completion.Usage.TotalTokenCount}");
    
    var assistantMessage = new AssistantChatMessage(request);
    chatHistory.Add(assistantMessage);
    
    CliInterface.BreakLine();
}


AzureOpenAIClient GetClient()
{
    var key = config["AzureOpenAi:Key"]!;
    var endpoint = config["AzureOpenAi:Endpoint"]!;
    
    return new AzureOpenAIClient(
        new Uri(endpoint), 
        new AzureKeyCredential(key));
}

ChatClient GetChatClient()
{
    return client.GetChatClient(config["AzureOpenAi:Model"]!);
}
