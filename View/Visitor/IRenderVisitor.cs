using Model;
using Action = Model.Action;

namespace View;

public abstract class RenderVisitor : IVisitor
{
    public string Result { get; protected set; } = "";

    public virtual void Visit(SimpleState state)
    {
        Result = Render(state);
    }

    public virtual void Visit(InitialState state)
    {
        Result = Render(state);
    }

    public virtual void Visit(FinalState state)
    {
        Result = Render(state);
    }

    public virtual void Visit(CompoundState state)
    {
        Result = Render(state);
    }

    public virtual void Visit(Trigger trigger)
    {
        Result = Render(trigger);
    }

    public virtual void Visit(Action action)
    {
        Result = Render(action);
    }

    public virtual void Visit(Transition transition)
    {
        Result = Render(transition);
    }

    // Abstracte methods die je concrete subclass moet implementeren
    protected abstract string Render(SimpleState state);
    protected abstract string Render(InitialState state);
    protected abstract string Render(FinalState state);
    protected abstract string Render(CompoundState state);
    protected abstract string Render(Trigger trigger);
    protected abstract string Render(Action action);
    protected abstract string Render(Transition transition);
}