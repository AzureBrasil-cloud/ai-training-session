using System.Text.Json;
using OpenAI.Assistants;
#pragma warning disable OPENAI001

namespace BlogWriterAssistantApp.Tools;

public class EmailTool : ITool
{
    public static string Name => nameof(EmailTool);

    public static FunctionToolDefinition Definition => new(Name)
    {
        Description = "Send e-mail",
        Parameters = BinaryData.FromObjectAsJson(
            new
            {
                Type = "object",
                Properties = new
                {
                    ReceiverEmail = new
                    {
                        Type = "string",
                        Description = "The e-mail of the person who will receive the email",
                    },
                    Subject = new
                    {
                        Type = "string",
                        Description = "The e-mail subject",
                    },
                    Message = new
                    {
                        Type = "string",
                        Description = "The e-mail content. The email body message",
                    },
                },
                Required = new[] { "ReceiverEmail", "Subject", "Message" },
            },
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })};
    
    public Task<string> ExecuteAsync(ILogger logger, string receiverEmail, string subject, string message)
    {
        logger.LogInformation("Email sent! -> {to}, {subject}, {message}", receiverEmail, subject, $"{message[..20]}...");
        
        // YOUR IMPLEMENTATION HERE
        
        return Task.FromResult("Email sent successfully");
    }
}