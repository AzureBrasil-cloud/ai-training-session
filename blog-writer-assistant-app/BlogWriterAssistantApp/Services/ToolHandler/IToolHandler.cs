using OpenAI.Assistants;
#pragma warning disable OPENAI001

namespace BlogWriterAssistantApp.Services.ToolHandler;

public interface IToolHandler
{
    Task<ToolOutput> HandleAsync(RequiredAction requiredAction);
}