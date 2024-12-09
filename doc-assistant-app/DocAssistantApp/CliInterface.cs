using Spectre.Console;

namespace DocAssistantApp;

public static class CliInterface
{
    public static void WritePanel()
    {
        var panel = new Panel("Assistente com acesso a dados privados")
        {
            Header = new PanelHeader("Doc assistant"),
            Padding = new Padding(3, 0, 3, 0),
            Border = BoxBorder.Rounded
        };

        AnsiConsole.Write(panel);
    }
    
    public static string ReadConsole()
    {
        return AnsiConsole.Prompt(new TextPrompt<string>("\U0001F449 Como o [bold yellow]assistente[/] pode te ajudar?"));
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