using System.Text.Json;
using BlogWriterAssistantApp.Services.ChatCompletions;
using BlogWriterAssistantApp.Tools;
using OpenAI.Assistants;
#pragma warning disable OPENAI001

namespace BlogWriterAssistantApp.Services.ToolHandler;

public class ToolHandler(IChatCompletionsService chatCompletionsService) : IToolHandler
{
    public async Task<ToolOutput> HandleAsync(RequiredAction requiredAction)
    {
        using var argumentsJson = JsonDocument.Parse(requiredAction.FunctionArguments);

        // if (requiredAction.FunctionName == EmailTool.Name)
        // {
        //     return HandlerEmailTool(requiredAction, argumentsJson);
        // }
        
        if (requiredAction.FunctionName == BlogArticleWriterTool.Name)
        {
            return await HandlerBlogArticleWriterTool(requiredAction, argumentsJson);
        }
        
        return null!;
    }

    private async Task<ToolOutput> HandlerBlogArticleWriterTool(RequiredAction requiredAction, JsonDocument argumentsJson)
    {
        var title = argumentsJson.RootElement.GetProperty("title").GetString()!;
        var generalIdea = argumentsJson.RootElement.GetProperty("generalIdea").GetString()!;
        var numberOfWords = argumentsJson.RootElement.GetProperty("numberOfWords").GetInt32()!;

        var tool = new BlogArticleWriterTool();
        
        var result = await tool.ExecuteAsync(
            chatCompletionsService, 
            title, 
            generalIdea, 
            numberOfWords);
        
        return new ToolOutput(requiredAction.ToolCallId, result);
    }
}