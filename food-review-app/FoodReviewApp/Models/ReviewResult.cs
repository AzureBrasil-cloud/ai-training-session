using System.Globalization;

namespace FoodReviewApp.Models;

public record ReviewResult(decimal TokenUsageCost)
{
    public string TokenUsageCostUsd => TokenUsageCost.ToString("C8", CultureInfo.GetCultureInfo("en-US"));
    public string TokenUsageCostUsd1M => (TokenUsageCost * 1_000_000).ToString("C", CultureInfo.GetCultureInfo("en-US"));
}