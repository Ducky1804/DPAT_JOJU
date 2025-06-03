using System.Security.AccessControl;
using Model;
using View.Factory;
using View.Printer;
using View.Utils;

namespace View.Diagram.State;

public class CompoundStateRenderer : IRenderer<CompoundState>
{
    public string Render(CompoundState compound)
    {
        return RenderChildren(compound);
    }

    private string RenderChildren(CompoundState compound)
    {
        string result = "";

        foreach (var child in compound.Children)
        {
            if (child is CompoundState compoundState)
            {
                result += RenderChildren(compoundState);
            }
            else
            {
                var renderer = new SimpleStateRenderer();
                
                String content = renderer.Render((SimpleState) child);
                result += content;
            }

            result += "\r\n";
        }

        Rectangle rectangle = new Rectangle();
        new ConsolePrinter().PrintLines(rectangle.DrawConsoleRectangle("\ud83d\udca8 Compound: " + compound.Name, result));
        return "";
    }
}