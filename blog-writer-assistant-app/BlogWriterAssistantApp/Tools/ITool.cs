using OpenAI.Assistants;
#pragma warning disable OPENAI001

namespace BlogWriterAssistantApp.Tools;

public interface ITool
{
    public static abstract string Name { get; }

    public static abstract FunctionToolDefinition Definition { get; }
}