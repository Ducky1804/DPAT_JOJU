namespace Model;

public interface IVisitor
{
    void Visit(SimpleState state);
    void Visit(InitialState state);
    void Visit(FinalState state);
    void Visit(CompoundState state);
    void Visit(Trigger trigger);
    void Visit(Action action);
    void Visit(Transition transition);
}