namespace View.Printer;

public class ConsolePrinter(ConsoleColor color = ConsoleColor.White) : IPrinter
{
    
    public virtual void Print(string content)
    {
        var previousColor = Console.ForegroundColor;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int x = (Console.WindowWidth - content.Length) / 2;
        if (x < 0) x = 0;

        Console.SetCursorPosition(x, Console.CursorTop);
        Console.ForegroundColor = color;
        Console.WriteLine(content);
        Console.ForegroundColor = previousColor;
    }
}