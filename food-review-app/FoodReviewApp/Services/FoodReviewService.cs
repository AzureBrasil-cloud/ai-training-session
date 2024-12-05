using Azure;
using Azure.AI.OpenAI;
using FoodReviewApp.Models;
using OpenAI.Chat;

namespace FoodReviewApp.Services;

public class FoodReviewService(IConfiguration configuration)
{
    public async Task<BinaryClassificationReviewResult> BinaryClassificationAsync(ReviewRequest reviewRequest)
    {
        var client = GetClient();
        
        ChatCompletion completion = await client.CompleteChatAsync(
        [
            new SystemChatMessage(Constants.BinaryClassificationPrompt),
            new UserChatMessage(reviewRequest.Content)
        ]);

        var result = completion.Content[0].Text;

        return new BinaryClassificationReviewResult(
            result.ToLower().Contains("positive".ToLower()),
            CalculateTokenUsageCost(completion));
    }
    
    public async Task<MultiClassificationReviewResult> MultiClassificationAsync(ReviewRequest reviewRequest)
    {
        var client = GetClient();
        
        ChatCompletion completion = await client.CompleteChatAsync(
        [
            new SystemChatMessage(Constants.MultiClassificationPrompt),
            new UserChatMessage(reviewRequest.Content)
        ]);

        var result = completion.Content[0].Text;

        return new MultiClassificationReviewResult(
            (ReviewResultType)Convert.ToInt16(result),
            CalculateTokenUsageCost(completion));
    }

    private decimal CalculateTokenUsageCost(ChatCompletion completion)
    {
        var inputPrice = configuration.GetValue<decimal>("AzureOpenAi:InputPrice"); // 1M tokens
        var outputPrice = configuration.GetValue<decimal>("AzureOpenAi:OutputPrice"); // 1M tokens

        var inputTokensCost =  completion.Usage.InputTokenCount * (inputPrice)/1_000_000;
        var outputTokensCost = completion.Usage.OutputTokenCount * (outputPrice)/1_000_000;
        
        return  inputTokensCost + outputTokensCost;
    }

    private ChatClient GetClient()
    {
        string endpoint = configuration["AzureOpenAi:Endpoint"]!;
        string key = configuration["AzureOpenAi:Key"]!;

        AzureOpenAIClient azureClient = new(new Uri(endpoint), new AzureKeyCredential(key));
        
        return azureClient.GetChatClient(configuration["AzureOpenAi:Model"]!);
    }
}