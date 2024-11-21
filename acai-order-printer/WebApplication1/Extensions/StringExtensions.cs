namespace WebApplication1.Extensions;

public static class StringExtensions
{
    public static string ClearJson(this string input)
    {
        // Clear OpenAI Json tags from the response
        return string.IsNullOrWhiteSpace(input) ? input : input.Replace("```json\n", "").Replace("```", "");
    }
}