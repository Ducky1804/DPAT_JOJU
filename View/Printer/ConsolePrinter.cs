namespace View.Printer;

public class ConsolePrinter(ConsoleColor color = ConsoleColor.White) : IPrinter
{
    public virtual void Print(string content)
    {
        bool HasConsole =
            !Console.IsOutputRedirected &&
            !Console.IsInputRedirected &&
            !Console.IsErrorRedirected;

        if (!HasConsole) return;
        
        var previousColor = Console.ForegroundColor;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int x = (Console.WindowWidth - content.Length) / 2;
        if (x < 0) x = 0;

        Console.SetCursorPosition(x, Console.CursorTop);
        Console.ForegroundColor = color;
        Console.WriteLine(content);
        Console.ForegroundColor = previousColor;
    }

    public void PrintLines(List<string> lines, bool centerVertically = true)
    {
        bool HasConsole =
            !Console.IsOutputRedirected &&
            !Console.IsInputRedirected &&
            !Console.IsErrorRedirected;

        if (!HasConsole) return;
        
        var previousColor = Console.ForegroundColor;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int consoleWidth = Console.WindowWidth;
        int consoleHeight = Console.WindowHeight;

        int verticalPadding = centerVertically ? Math.Max(0, (consoleHeight - lines.Count) / 2) : 0;

        // Vertical padding (lege regels erboven)
        for (int i = 0; i < verticalPadding; i++)
        {
            Console.WriteLine();
        }

        Console.ForegroundColor = color;

        foreach (var line in lines)
        {
            int x = (consoleWidth - line.Length) / 2;
            if (x < 0) x = 0;

            Console.SetCursorPosition(x, Console.CursorTop);
            Console.WriteLine(line);
        }

        Console.ForegroundColor = previousColor;
    }
}