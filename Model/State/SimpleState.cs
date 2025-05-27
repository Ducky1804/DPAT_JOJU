namespace Model;

public class SimpleState : State
{
    public SimpleState(string id, string name) : base(id, name)
    {
    }

    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}