using System.Globalization;

namespace BlogWriterAssistantApp.Models;

public record RunResponse(string Message, decimal TokenUsageCost)
{
    public string TokenUsageCostUsd => TokenUsageCost.ToString("C8", CultureInfo.GetCultureInfo("en-US"));
    public string TokenUsageCostUsd1M => (TokenUsageCost * 1_000_000).ToString("C", CultureInfo.GetCultureInfo("en-US"));
}