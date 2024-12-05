using System.Text.Json;
using BlogWriterAssistantApp.Services.ChatCompletions;
using OpenAI.Assistants;
#pragma warning disable OPENAI001

namespace BlogWriterAssistantApp.Tools;

public class BlogArticleWriterTool : ITool
{
    public static string Name => nameof(BlogArticleWriterTool);

    public static FunctionToolDefinition Definition => new(Name)
    {
        Description = "Write article for a personal tech blog",
        Parameters = BinaryData.FromObjectAsJson(
            new
            {
                Type = "object",
                Properties = new
                {
                    Title = new
                    {
                        Type = "string",
                        Description = "The title of the article",
                    },
                    GeneralIdea = new
                    {
                        Type = "string",
                        Description = "The idea of the article",
                    },
                    NumberOfWords = new
                    {
                        Type = "integer",
                        Description = "The number of words",
                    },
                },
                Required = new[] { "Title", "GeneralIdea", "NumberOfWords" },
            },
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })};
    
    public async Task<string> ExecuteAsync(
        IChatCompletionsService chatCompletionsService, 
        string title, 
        string generalIdea, 
        int numberOfWords)
    {
        var formattedMsg = Constants.BlogArticleWriterToolPrompt
            .Replace("{generalIdea}", generalIdea)
            .Replace("{title}", title)
            .Replace("{numberOfWords}", numberOfWords.ToString());
        
        var result = await chatCompletionsService.CompleteAsync(formattedMsg);

        return result;
    }
}