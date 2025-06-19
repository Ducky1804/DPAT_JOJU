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
        var resultBuilder = new System.Text.StringBuilder();

        for (int i = 0; i < compound.Children.Count; i++)
        {
            var child = compound.Children[i];

            if (child is CompoundState compoundState)
            {
                resultBuilder.Append(RenderChildren(compoundState));
            }
            else
            {
                var renderer = new SimpleStateRenderer();
                string content = renderer.Render((SimpleState)child);
                resultBuilder.Append(content);
            }

            if (i < compound.Children.Count - 1)
            {
                resultBuilder.AppendLine();
                resultBuilder.AppendLine();
            }
        }

        Rectangle rectangle = new Rectangle();
        return rectangle.DrawConsoleRectangle("💨 Compound: " + compound.Name, resultBuilder.ToString()).ConvertToString();
    }
}