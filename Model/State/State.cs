namespace Model;

public abstract class State : Nameable
{
    public State ParentState { get; set; }
    
    protected State(string id, string name) : base(id, name)
    {
    }
}