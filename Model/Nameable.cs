namespace Model;

public abstract class Nameable : Identifiable
{
    public String Name { get; set; }
    
    protected Nameable(string id, string name) : base(id)
    {
        Name = name;
    }
}