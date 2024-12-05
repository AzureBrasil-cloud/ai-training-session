namespace FoodReviewApp.Models;

public record MultiClassificationReviewResult(ReviewResultType Type, decimal TokenUsageCost) : ReviewResult(TokenUsageCost)
{
    public string Description => Type.ToString();
};