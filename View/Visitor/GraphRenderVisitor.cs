using Model;
using View;
using View.Diagram;
using View.Diagram.Action;
using View.Factory;
using Action = Model.Action;

public class GraphRenderVisitor : RenderVisitor
{
    private readonly RenderFactory _renderFactory = RenderFactory.Instance;

    protected override string Render(SimpleState state)
    {
        return _renderFactory.CreateStateRenderer<SimpleState>(state, state.GetType()).Render(state);
    }

    protected override string Render(InitialState state)
    {
        return _renderFactory.CreateStateRenderer<InitialState>(state, state.GetType()).Render(state);
    }

    protected override string Render(FinalState state)
    {
        return _renderFactory.CreateStateRenderer<FinalState>(state, state.GetType()).Render(state);
    }

    protected override string Render(CompoundState state)
    {
        return _renderFactory.CreateStateRenderer<CompoundState>(state, state.GetType()).Render(state);
    }

    protected override string Render(Trigger trigger)
    {
        return trigger.ToString();
    }

    protected override string Render(Action action)
    {
        return new ActionRenderer().Render(action);
    }

    protected override string Render(Transition transition)
    {
        return new TransitionRenderer().Render(transition);
    }
}