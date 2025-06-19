using View.Printer;
using View.Utils;

namespace View.Diagram;

using Model;

public class StateDiagramRenderer
{
    public string Render(Diagram t, RenderVisitor renderMethod)
    {
        string header = new HeaderRenderer().Render(t.Name);
        new BoxedContentPrinter(ConsoleColor.Yellow).Print(header);

        List<string> content = new();
        foreach (var state in t.States)
        {
            state.Accept(renderMethod);

            content.Add(renderMethod.Result);

            foreach (var transition in state.Transitions)
            {
                transition.Accept(renderMethod);

                content.Add(renderMethod.Result);
            }
        }
        
        new ConsolePrinter().PrintLines(content);
        return string.Join("\r\n", content);
    }

}