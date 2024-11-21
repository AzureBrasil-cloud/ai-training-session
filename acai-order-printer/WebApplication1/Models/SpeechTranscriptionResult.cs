namespace WebApplication1.Models;

public class SpeechTranscriptionResult
{
    public long Duration { get; set; }
    public List<CombinedPhrase> CombinedPhrases { get; set; } = new();
}

public class CombinedPhrase
{
    public int Channel { get; set; }
    public string Text { get; set; }
}