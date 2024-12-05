using BlogWriterAssistantApp.Models;

namespace BlogWriterAssistantApp.Services.Assistants;

public interface IAssistantService
{
    Task<AssistantResponse> CreateAssistantAsync(CreateAssistantRequest request);
}