namespace View.Printer;

public class ConsolePrinter(ConsoleColor color = ConsoleColor.White) : IPrinter
{
    
    public virtual void Print(string content)
    {
        var previousColor = Console.ForegroundColor;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.SetCursorPosition((Console.WindowWidth - content.Length) / 2, Console.CursorTop);
        Console.ForegroundColor = color;
        Console.WriteLine(content);
        Console.ForegroundColor = previousColor;
    }
}