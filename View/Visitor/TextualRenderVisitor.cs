using Model;
using View.Printer;
using Action = Model.Action;

namespace View;

public class TextualRenderVisitor : RenderVisitor
{
    protected override string Render(SimpleState state)
    {
        throw new NotImplementedException();
    }

    protected override string Render(InitialState state)
    {
        throw new NotImplementedException();
    }

    protected override string Render(FinalState state)
    {
        throw new NotImplementedException();
    }

    protected override string Render(CompoundState state)
    {
        throw new NotImplementedException();
    }

    protected override string Render(Trigger trigger)
    {
        throw new NotImplementedException();
    }

    protected override string Render(Action action)
    {
        throw new NotImplementedException();
    }

    protected override string Render(Transition transition)
    {
        throw new NotImplementedException();
    }
}