using Model;
using View.Diagram.Action;
using View.Diagram.State;
using View.Printer;
using View.Utils;
using Action = System.Action;

public class RenderVisitor(Model.Diagram diagram) : IVisitor
{
    private readonly Rectangle rectangle = new();

    public void Visit(SimpleState state)
    {
        var lines = RenderStateWithRectangle(state);
        new ConsolePrinter().Print(lines);
    }

    public void Visit(InitialState state)
    {
        var lines = RenderStateWithRectangle(state);
        new ConsolePrinter().Print(lines);
    }

    public void Visit(FinalState state)
    {
        var lines = RenderStateWithRectangle(state);
        new ConsolePrinter().Print(lines);
    }

    public void Visit(CompoundState state)
    {
        var lines = RenderStateWithRectangle(state);
        new ConsolePrinter().Print(lines);
    }

    // Nieuwe helpermethode die elke state recursief rendert in een rechthoek en de strings teruggeeft
    private string RenderStateWithRectangle(Model.State state)
    {
        string header = state.GetType().Name + ": " + state.Name;
        string description = "";

        switch (state)
        {
            case SimpleState simple:
                description = new SimpleStateRenderer().Render(simple);
                break;

            case CompoundState compound:
                description = new CompoundStateRenderer().Render(compound);
                // Recursief children toevoegen als rectangles, onder elkaar
                foreach (var child in compound.Children)
                {
                    var childLines = RenderStateWithRectangle(child);
                    description += "\n" + string.Join("\n", childLines);
                }
                break;
        }
        
        return String.Join("\r\n", rectangle.DrawConsoleRectangle(header, description.Trim()));
    }

    public void Visit(Trigger trigger)
    {
        // Geen rendering?
    }

    public void Visit(Model.Action action)
    {
        string content = new ActionRenderer().Render(action);
        new ConsolePrinter().Print(content);
    }

    public void Visit(Transition transition)
    {
        // Geen rendering?
    }
}
