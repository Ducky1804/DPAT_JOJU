using View.Printer;
using View.Utils;

namespace View.Diagram;

using Model;

public class StateDiagramRenderer
{
    public string Render(Diagram t, IVisitor renderMethod)
    {
        string content = new HeaderRenderer().Render(t.Name);
        new BoxedContentPrinter(ConsoleColor.Yellow).Print(content);

        IVisitor visitor = renderMethod;
        foreach (var state in t.States)
        {
            state.Accept(visitor);
            
            foreach (var transition in state.Transitions)
            {
                transition.Accept(visitor);
            }
        }

        return "";
    }
}