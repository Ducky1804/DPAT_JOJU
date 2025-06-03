using View.Printer;
using View.Utils;

namespace View.Diagram;

using Model;

public class StateDiagramRenderer : IRenderer<Diagram>
{
    public string Render(Diagram t)
    {
        string content = new HeaderRenderer().Render(t.Name);
        new BoxedContentPrinter(ConsoleColor.Yellow).Print(content);
        
        IVisitor visitor = new RenderVisitor();
        foreach (var state in t.States)
        {
            state.Accept(visitor);
        }

        return "";
    }
}