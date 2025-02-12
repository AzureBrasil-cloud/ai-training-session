
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;

// Create a kernel with Azure OpenAI chat completion
#pragma warning disable SKEXP0001, SKEXP0003, SKEXP0010, SKEXP0011, SKEXP0050, SKEXP0052
var builder = Kernel.CreateBuilder().AddOpenAIChatCompletion(
    modelId: "Phi-3-5-mini-instruct-lfqzp", 
    endpoint: new Uri("https://Phi-3-5-mini-instruct-lfqzp.eastus2.models.ai.azure.com"), 
    apiKey: Environment.GetEnvironmentVariable("AZML_MODEL_KEY"));

// Add enterprise components
builder.Services.AddLogging(services => services.AddConsole().SetMinimumLevel(LogLevel.Information));

// Build the kernel
Kernel kernel = builder.Build();

// invoke a simple prompt to the chat service
string prompt = "Write a joke about dogs";
var response = await kernel.InvokePromptAsync(prompt);
Console.WriteLine(response.GetValue<string>());
