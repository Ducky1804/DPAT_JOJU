using View.Printer;
using View.Utils;

namespace View.Diagram;

using Model;

public class StateDiagramRenderer : IRenderer<Diagram>
{
    public string Render(Diagram t)
    {
        // Header
        new BoxedContentPrinter(ConsoleColor.Yellow).Print(t.Name);
        
        IVisitor visitor = new RenderVisitor(t);
        foreach (var state in t.States)
        {
            state.Accept(visitor);
        }

        foreach (var trigger in t.Triggers)
        {
            trigger.Accept(visitor);
        }

        foreach (var transition in t.Transitions)
        {
            transition.Accept(visitor);
        }

        return "";
    }
}