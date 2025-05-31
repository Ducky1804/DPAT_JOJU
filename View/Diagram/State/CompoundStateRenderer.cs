using System.Security.AccessControl;
using Model;
using View.Factory;
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
                var renderer = RenderFactory.Instance.CreateStateRenderer(child);
                
                String content = renderer.Render(child);
                result += content;
            }

            result += "\r\n";
            result += "\r\n";
        }

        Rectangle rectangle = new Rectangle();
        return String.Join("\r\n",
            rectangle.DrawConsoleRectangle("\ud83d\udca8 Compound: " + compound.Name, result));
    }
}