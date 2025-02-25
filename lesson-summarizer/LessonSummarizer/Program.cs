#pragma warning disable OPENAI001
using Azure;
using Azure.AI.OpenAI;
using LessonSummarizer;
using Microsoft.Extensions.Configuration;
using OpenAI.Assistants;

var builder = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

IConfiguration config = builder.Build();

var client = GetClient();
var assistantClient = client.GetAssistantClient();

AssistantThread thread = await assistantClient.CreateThreadAsync();
Assistant assistant = await CreateAssistantAsync();

CliInterface.WritePanel();
    
while (true)
{
    var request = CliInterface.ReadConsole();

    if (string.Compare(request, "exit", StringComparison.OrdinalIgnoreCase) == 0)
    {
        break;
    }

    await assistantClient.CreateMessageAsync(thread.Id , MessageRole.User, [MessageContent.FromText(request)]);
        
    ThreadRun threadRun = await assistantClient.CreateRunAsync(thread.Id, assistant.Id);
        
    do
    {
        await Task.Delay(TimeSpan.FromMilliseconds(100));
        threadRun = await assistantClient.GetRunAsync(thread.Id, threadRun.Id);
    }
    while (threadRun.Status == RunStatus.Queued || threadRun.Status == RunStatus.InProgress);
        
    var messagePage = assistantClient.GetMessagesAsync(
        thread.Id,
        new MessageCollectionOptions
        {
            PageSizeLimit = 1,
            Order = MessageCollectionOrder.Descending,
        });
    
    await using var enumerator = messagePage.GetAsyncEnumerator();
    var messageItem = await enumerator.MoveNextAsync() ? enumerator.Current : null;
    
    CliInterface.WriteLine($"{Environment.NewLine}\U0001F60A Assistente {Environment.NewLine}");
    
    foreach (var contentItem in messageItem!.Content)
    {
        if (!string.IsNullOrEmpty(contentItem.Text))
        {
            CliInterface.WriteLine($"{contentItem.Text}");
        }
    } 
            
    CliInterface.WriteLine($"\U0001F4B0 Tokens de saída: {threadRun.Usage.OutputTokenCount}");
    CliInterface.WriteLine($"\U0001F4B0 Tokens de entrada: {threadRun.Usage.InputTokenCount}");
    CliInterface.WriteLine($"\U0001F4B0 Total de tokens: {threadRun.Usage.TotalTokenCount}");
    
    CliInterface.BreakLine();
}

await assistantClient.DeleteThreadAsync(thread.Id);
await assistantClient.DeleteAssistantAsync(assistant.Id);

    
async Task<Assistant> CreateAssistantAsync()
{
    // Create assistant
    var assistantOptions = new AssistantCreationOptions
    {
        Name = "my-assistant",
        Instructions = Constants.AssistantInstructions
    };
    
    return await assistantClient.CreateAssistantAsync(config["AzureOpenAi:Model"]!, assistantOptions);
}

AzureOpenAIClient GetClient()
{
    var key = config["AzureOpenAi:Key"]!;
    var endpoint = config["AzureOpenAi:Endpoint"]!;
    
    return new AzureOpenAIClient(
        new Uri(endpoint), 
        new AzureKeyCredential(key));
}