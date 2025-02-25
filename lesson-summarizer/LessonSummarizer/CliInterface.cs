using Spectre.Console;

namespace LessonSummarizer;

public static class CliInterface
{
    public static void WritePanel()
    {
        var panel = new Panel("Assistente do evento")
        {
            Header = new PanelHeader("Assistente"),
            Padding = new Padding(3, 0, 3, 0),
            Border = BoxBorder.Rounded
        };

        AnsiConsole.Write(panel);
    }
    
    public static string ReadConsole()
    {
        return AnsiConsole.Prompt(new TextPrompt<string>("\U0001F449 Qual a sua dúvida sobre o evento [bold yellow]Azure AI training[/] ?"));
    }
    
    public static void WriteLine(string message)
    {
        AnsiConsole.MarkupLine(message);
    }
    
    public static void BreakLine()
    {
        AnsiConsole.MarkupLine(Environment.NewLine);
    }
}