namespace Model;

public class Action : Describable
{
    public String Type { get; set; }
    
    public Action(string id, string description, string type) : base(id, description)
    {
        Type = type;
    }
    
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}