namespace BlogWriterAssistantApp.Models;

public record RunRequest(string AssistantId, string ThreadId, string Message);