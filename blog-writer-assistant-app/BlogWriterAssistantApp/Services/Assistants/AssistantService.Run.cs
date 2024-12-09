using BlogWriterAssistantApp.Models;
using OpenAI.Assistants;

#pragma warning disable OPENAI001

namespace BlogWriterAssistantApp.Services.Assistants;

public partial class AssistantService
{
    public async Task<RunResponse> RunAsync(RunRequest request)
    {
        var client = GetClient();
        var assistantClient = client.GetAssistantClient();

        var thread = (await assistantClient.GetThreadAsync(request.ThreadId)).Value;
        var assistant = (await assistantClient.GetAssistantAsync(request.AssistantId)).Value;
        
        await assistantClient.CreateMessageAsync(thread.Id, MessageRole.User, [MessageContent.FromText(request.Message)
        ]);
        
        ThreadRun threadRun = await assistantClient.CreateRunAsync(thread.Id, assistant.Id);
        
        do
        {
            await Task.Delay(TimeSpan.FromMilliseconds(100));
            
            threadRun = await assistantClient.GetRunAsync(thread.Id, threadRun.Id);
            
            if (threadRun.Status == RunStatus.RequiresAction)
            {
                List<ToolOutput> toolOutputs = new();
                foreach (var requiredAction in threadRun.RequiredActions)
                {
                    var result = await toolHandler.HandleAsync(requiredAction);
                    
                    toolOutputs.Add(result);
                }
                
                threadRun = await assistantClient.SubmitToolOutputsToRunAsync(thread.Id, threadRun.Id, toolOutputs);
            }
        }
        while (threadRun.Status == RunStatus.Queued || threadRun.Status == RunStatus.InProgress);
        
        var messagePage = assistantClient.GetMessagesAsync(
            thread.Id,
            new MessageCollectionOptions
            {
                PageSizeLimit = 1,
                Order = MessageCollectionOrder.Descending,
            });
        
        await using var enumerator = messagePage.GetAsyncEnumerator();
        var messageItem = await enumerator.MoveNextAsync() ? enumerator.Current : null;

        return new RunResponse(
            messageItem?.Content.FirstOrDefault()?.Text ?? string.Empty,
            CalculateTokenUsageCost(threadRun.Usage));
    }
}