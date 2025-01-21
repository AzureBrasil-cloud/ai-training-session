using Spectre.Console;

namespace DocAssistantApp;

public static class CliInterface
{
    public static void WritePanel()
    {
        var panel = new Panel("Assistant with access to private data")
        {
            Header = new PanelHeader("Doc assistant"),
            Padding = new Padding(3, 0, 3, 0),
            Border = BoxBorder.Rounded
        };

        AnsiConsole.Write(panel);
    }
    
    public static string ReadConsole()
    {
        return AnsiConsole.Prompt(new TextPrompt<string>("\U0001F449 How can the [bold yellow]assistant[/] help you?"));
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