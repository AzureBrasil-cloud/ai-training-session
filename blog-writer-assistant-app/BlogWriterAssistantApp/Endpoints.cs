using BlogWriterAssistantApp.Models;
using BlogWriterAssistantApp.Services.Assistants;
using BlogWriterAssistantApp.Services.Threads;

namespace BlogWriterAssistantApp;

public static class Endpoints
{
    public static WebApplication UseAppEndpoints(this WebApplication app)
    {
        app.MapPost("/assistants", async (CreateAssistantRequest request, IAssistantService service) => 
                Results.Ok(await service.CreateAssistantAsync(request)))
            .WithName("CreateAssistant")
            .WithOpenApi();
        
        app.MapPost("/threads", async (IThreadService service) => 
                Results.Ok(await service.CreateThreadAsync()))
            .WithName("CreateThread")
            .WithOpenApi();

        return app;
    }
}