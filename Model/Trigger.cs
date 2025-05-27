namespace Model;

public class Trigger : Identifiable
{
    public Trigger(string id, string description) : base(id)
    {
        Description = description;
    }

    public String Description { get; set; }
    
    public override string ToString()
    {
        return $"Trigger [Id={Id}, Description={Description}]";
    }
    
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}