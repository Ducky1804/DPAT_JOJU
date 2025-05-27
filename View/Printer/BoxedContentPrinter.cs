using View.Utils;

namespace View.Printer;

public class BoxedContentPrinter(ConsoleColor color = ConsoleColor.White) : ConsolePrinter(color)
{
    public override void Print(string content)
    {
        List<String> lines = new Rectangle().DrawConsoleRectangle(content);
        
        foreach (var line in lines)
        {
            base.Print(line);
        }
    }
    
    public void Print(string content, string? description, ConsoleColor header = ConsoleColor.Blue, ConsoleColor descriptionColor = ConsoleColor.Red )
    {
        List<string> lines;

        if (description == null)
        {
            this.Print(content);
            return;
        }
        else
        {
            lines = new Rectangle().DrawConsoleRectangle(content, description);
            bool separatorReached = false;

            foreach (var line in lines)
            {
                if (line.StartsWith("├")) separatorReached = true;

                Console.ForegroundColor = separatorReached ? descriptionColor : header;
                Console.WriteLine(line);
            }
        }

        Console.ResetColor();
    }
}