using BlogWriterAssistantApp.Models;

namespace BlogWriterAssistantApp.Services.Threads;

public interface IThreadService
{
    Task<ThreadResponse> CreateThreadAsync();
}