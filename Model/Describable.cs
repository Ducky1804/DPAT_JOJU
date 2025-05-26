namespace Model;

public abstract class Describable : Identifiable
{
    public String Description { get; set; }
    
    protected Describable(string id, string description) : base(id)
    {
        this.Description = description;
    }
}