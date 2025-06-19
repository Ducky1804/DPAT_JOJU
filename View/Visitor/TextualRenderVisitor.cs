using Model;
using View.Printer;
using Action = Model.Action;

namespace View;

public class TextualRenderVisitor : RenderVisitor
{
    protected override string Render(SimpleState state)
    {
        return "Idk";
    }

    protected override string Render(InitialState state)
    {
        return "Idk";
    }

    protected override string Render(FinalState state)
    {
        return "Idk";
    }

    protected override string Render(CompoundState state)
    {
        return "Idk";
    }

    protected override string Render(Trigger trigger)
    {
        return "Idk";
    }

    protected override string Render(Action action)
    {
        return "Idk";
    }

    protected override string Render(Transition transition)
    {
        return "Idk";
    }
}