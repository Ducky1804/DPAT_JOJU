namespace Model;

public class CompoundState : State
{
    public CompoundState(string id, string name) : base(id, name)
    {
    }
    
    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}