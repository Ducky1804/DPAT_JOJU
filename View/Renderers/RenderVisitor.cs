using Model;
using View.Diagram;
using View.Diagram.Action;
using View.Factory;
using View.Printer;

namespace View;

public class RenderVisitor : IVisitor
{
    private readonly RenderFactory _renderFactory = RenderFactory.Instance;

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
    }

    public void Visit(Model.Action action)
    {
        string content = new ActionRenderer().Render(action);
        new ConsolePrinter().Print(content);
    }

    public void Visit(Transition transition)
    {
        string content = new TransitionRenderer().Render(transition);
        new ConsolePrinter().Print(content);
}
}