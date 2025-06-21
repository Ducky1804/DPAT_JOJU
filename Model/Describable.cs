namespace Model;

public abstract class Describable : Identifiable
{
    public string Description { get; set; }
    
    protected Describable(string id, string description) : base(id)
    {
        this.Description = description;
    }
}