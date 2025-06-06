namespace Model.State;

public abstract class State : Nameable
{
    public List<State> Children { get; } = new();
    public List<Transition> Transitions { get; } = new();
    public Action? OnEntry { get; set; }
    public Action? OnExit { get; set; }
    
    protected State(string id, string name) : base(id, name)
    {
    }

    public void AddChild(State state)
    {
        Children.Add(state);
    }
    
    public abstract void Accept(IVisitor visitor);
}