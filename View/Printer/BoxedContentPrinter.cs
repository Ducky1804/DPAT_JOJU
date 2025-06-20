using View.Utils;

namespace View.Printer;

public class BoxedContentPrinter(ConsoleColor color = ConsoleColor.White) : ConsolePrinter(color)
{
    public override void Print(string content)
    {
        List<string> lines = new Rectangle().DrawConsoleRectangle(content);
        
        foreach (var line in lines)
        {
            base.Print(line);
        }
    }
}