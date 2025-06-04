using Model;
using View.Printer;
using Action = Model.Action;

namespace View;

public class TextualRenderVisitor : IVisitor
{
    public void Visit(SimpleState state)
    {
        new ConsolePrinter().Print(state.Name);
    }

    public void Visit(InitialState state)
    {
        new ConsolePrinter().Print(state.Name);
    }

    public void Visit(FinalState state)
    {
        new ConsolePrinter().Print(state.Name);
    }

    public void Visit(CompoundState state)
    {
        new ConsolePrinter().Print(state.Name);
    }

    public void Visit(Trigger trigger)
    {
    }

    public void Visit(Action action)
    {
    }

    public void Visit(Transition transition)
    {
    }
}