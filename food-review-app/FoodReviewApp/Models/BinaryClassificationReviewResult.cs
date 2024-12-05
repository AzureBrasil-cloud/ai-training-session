namespace FoodReviewApp.Models;

public record BinaryClassificationReviewResult(bool IsPositive, decimal TokenUsageCost) : ReviewResult(TokenUsageCost);