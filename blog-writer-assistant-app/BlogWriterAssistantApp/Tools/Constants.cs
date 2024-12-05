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
        Note 1: The result must in markdown format.
        Note 2: You must use the tag <br> in order to break lines and start new paragraphs
        """;
}