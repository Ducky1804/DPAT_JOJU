namespace Model;

public class FinalState : SimpleState
{
    public FinalState(string id, string name) : base(id, name)
    {
    }
    
    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}