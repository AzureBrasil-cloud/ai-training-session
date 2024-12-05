using System.Text.Json;
using OpenAI.Assistants;
#pragma warning disable OPENAI001

namespace BlogWriterAssistantApp.Tools;

public class WhatsAppSenderTool : ITool
{
    public static string Name => nameof(WhatsAppSenderTool);

    public static FunctionToolDefinition Definition => new(Name)
    {
        Description = "Send a WhatsApp message to a phone number",
        Parameters = BinaryData.FromObjectAsJson(
            new
            {
                Type = "object",
                Properties = new
                {
                    ReceiverNumber = new
                    {
                        Type = "string",
                        Description = "The phone number of the person who will receive the message",
                    },
                    Message = new
                    {
                        Type = "string",
                        Description = "The message content",
                    },
                },
                Required = new[] { "ReceiverNumber", "Message" },
            },
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })};
    
    public Task<string> ExecuteAsync(ILogger logger, string receiverNumber, string message)
    {
        logger.LogInformation("WhatsApp message sent! -> {to}, {message}", receiverNumber, $"{message[..20]}...");
        
        // YOUR IMPLEMENTATION HERE
        
        return Task.FromResult("WhatsApp message sent successfully");
    }
}