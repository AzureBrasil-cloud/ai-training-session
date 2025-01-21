#pragma warning disable OPENAI001
using System.Text;
using Azure;
using Azure.AI.OpenAI;
using DocAssistantApp;
using Microsoft.Extensions.Configuration;
using OpenAI.Assistants;
using OpenAI.Files;
using OpenAI.VectorStores;

var builder = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

IConfiguration config = builder.Build();

var client = GetClient();
var assistantClient = client.GetAssistantClient();
var vectorStoreClient = client.GetVectorStoreClient();
var fileClient = client.GetOpenAIFileClient();

VectorStore vectorStore = await CreateVectorStore();
OpenAIFile file = await UploadFileAsync();
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
    
    CliInterface.WriteLine($"{Environment.NewLine}\U0001F60A Assistant {Environment.NewLine}");
    
    foreach (var contentItem in messageItem!.Content)
    {
        if (!string.IsNullOrEmpty(contentItem.Text))
        {
           var text = contentItem.Text;
           
            if (contentItem.TextAnnotations.Count > 0)
            {
                foreach (var annotation in contentItem.TextAnnotations)
                {
                    text = text.Replace(annotation.TextToReplace, $" (\U0001F4D5 Document Id: {annotation.InputFileId})");
                }
            }
            
            CliInterface.WriteLine($"{text}");
        }
    } 
            
    CliInterface.WriteLine($"\U0001F4B0 Output tokens: {threadRun.Usage.OutputTokenCount}");
    CliInterface.WriteLine($"\U0001F4B0 Input tokens: {threadRun.Usage.InputTokenCount}");
    CliInterface.WriteLine($"\U0001F4B0 Total de tokens: {threadRun.Usage.TotalTokenCount}");
    
    CliInterface.BreakLine();
}

await fileClient.DeleteFileAsync(file.Id);
await vectorStoreClient.DeleteVectorStoreAsync(vectorStore.Id);
await assistantClient.DeleteThreadAsync(thread.Id);
await assistantClient.DeleteAssistantAsync(assistant.Id);

async Task<OpenAIFile> UploadFileAsync()
{
    byte[] byteArray = Encoding.UTF8.GetBytes(Constants.FileContent);

    using var stream = new MemoryStream(byteArray);
    
    var result = await fileClient.UploadFileAsync(stream, Constants.FileName, FileUploadPurpose.Assistants);
    
    await vectorStoreClient.AddFileToVectorStoreAsync(vectorStore.Id, result.Value.Id, true);
    
    return result.Value!;
}

async Task<VectorStore> CreateVectorStore()
{
    var result = await vectorStoreClient.CreateVectorStoreAsync(true, new VectorStoreCreationOptions
    {
        Name = "Docs"
    });

    return result.Value!;
}
    
async Task<Assistant> CreateAssistantAsync()
{
    // Create assistant
    var assistantOptions = new AssistantCreationOptions
    {
        Name = "my-assistant",
        Instructions = Constants.AssistantInstructions,
        Tools = { new FileSearchToolDefinition() },
        ToolResources = new ToolResources()
        {
            
            FileSearch = new FileSearchToolResources
            {
                VectorStoreIds = { vectorStore.Id }
            }
        }
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