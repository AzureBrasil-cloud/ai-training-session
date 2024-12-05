namespace BlogWriterAssistantApp.Tools;

public class Constants
{
    public const string BlogArticleWriterToolPrompt = 
        """
        Create a article about '{generalIdea}' in {numberOfWords} words.
        
        Use the '{title}' as title.
        Outputs only the article 
        -----
        Outputs the article in the following schema:

        <title>
        
        <content>
        
        -----
        """;
}