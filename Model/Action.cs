using Model.Enums;

namespace Model;

public class Action : Describable
{
    public ActionType Type { get; set; }
    
    public Action(string id, string description, ActionType type) : base(id, description)
    {
        Type = type;
    }
    
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}