namespace Model;

public class InitialState : SimpleState
{
    public InitialState(string id, string name) : base(id, name)
    {
    }
    
    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}