using System.Text.Json;
using BlogWriterAssistantApp.Services.ChatCompletions;
using BlogWriterAssistantApp.Tools;
using OpenAI.Assistants;
#pragma warning disable OPENAI001

namespace BlogWriterAssistantApp.Services.ToolHandler;

public class ToolHandler(IChatCompletionsService chatCompletionsService, ILogger<ToolHandler> logger) : IToolHandler
{
    public async Task<ToolOutput> HandleAsync(RequiredAction requiredAction)
    {
        using var argumentsJson = JsonDocument.Parse(requiredAction.FunctionArguments);

        if (requiredAction.FunctionName == EmailTool.Name)
        {
            return await HandlerEmailToolAsync(requiredAction, argumentsJson);
        }
        
        if (requiredAction.FunctionName == BlogArticleWriterTool.Name)
        {
            return await HandlerBlogArticleWriterTool(requiredAction, argumentsJson);
        }
        
        return null!;
    }
    
    private async Task<ToolOutput> HandlerEmailToolAsync(RequiredAction requiredAction, JsonDocument argumentsJson)
    {
        string receiverEmail = argumentsJson.RootElement.GetProperty("receiverEmail").GetString()!;
        string subject = argumentsJson.RootElement.GetProperty("subject").GetString()!;
        string message = argumentsJson.RootElement.GetProperty("message").GetString()!;

        var tool = new EmailTool();
        
        var result = await tool.ExecuteAsync(
            logger, 
            receiverEmail, 
            subject,
            message);
        
        return new ToolOutput(requiredAction.ToolCallId, result);
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