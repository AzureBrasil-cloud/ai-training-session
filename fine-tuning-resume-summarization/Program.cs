using System.ClientModel;
using Azure.AI.OpenAI;
using OpenAI.Chat;

const string systemMessage = """
    "You are a helpful RH assistant that create  Input summarizations.
    """;

var resume = """
             Ethan Reynolds is a 29-year-old Full Stack Developer with over five years of experience in designing, building, and maintaining high-traffic web applications using Node.js, React, and PostgreSQL. He has driven key projects at ByteLeap and CloudGrid, emphasizing clean coding practices, agile collaboration, and user-focused solutions that scale efficiently under peak demands. Known for his strong communication skills, Ethan excels at translating complex technical requirements into clear, actionable strategies while working seamlessly with cross-functional teams. Committed to continuous learning and fluent in English, he stays at the forefront of emerging technologies and industry trends, ensuring that the applications he develops consistently meet evolving business and user needs.
             """;

string key = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY")!;
string model = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_MODEL")!;
string url = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_URL")!;

AzureOpenAIClient azureClient = new(
    new Uri(url),
    new ApiKeyCredential(key));

ChatClient chatClient = azureClient.GetChatClient(model);

ChatCompletion completion = chatClient.CompleteChat(
[
    new SystemChatMessage(systemMessage),
    new UserChatMessage(resume)
]);

Console.WriteLine($"Output: {completion.Content[0].Text}");
Console.WriteLine($"Total of tokens: {completion.Usage.TotalTokenCount}");