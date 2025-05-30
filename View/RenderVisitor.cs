using Model;
using View;
using View.Diagram.Action;
using View.Diagram.State;
using View.Factory;
using View.Printer;
using View.Utils;
using Action = System.Action;

public class RenderVisitor : IVisitor
{
    private readonly RenderFactory _renderFactory = new();

    public void Visit(SimpleState state)
    {
        IRenderer<SimpleState> renderer = _renderFactory.CreateStateRenderer(state);
        String renderedComponent = renderer.Render(state);
        new ConsolePrinter().Print(renderedComponent);
    }

    public void Visit(InitialState state)
    {
        IRenderer<InitialState> renderer = _renderFactory.CreateStateRenderer(state);
        String renderedComponent = renderer.Render(state);
        new ConsolePrinter().Print(renderedComponent);
    }

    public void Visit(FinalState state)
    {
        IRenderer<FinalState> renderer = _renderFactory.CreateStateRenderer(state);
        string renderedComponent = renderer.Render(state);
        new ConsolePrinter().Print(renderedComponent);
    }

    public void Visit(CompoundState state)
    {
        IRenderer<CompoundState> renderer = _renderFactory.CreateStateRenderer(state);
        string renderedComponent = renderer.Render(state);
        new ConsolePrinter().Print(renderedComponent);
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
