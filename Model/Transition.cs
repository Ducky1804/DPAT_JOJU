namespace Model;

public class Transition : Identifiable
{
    public State Source { get; set; }
    public State Destination { get; set; }
    public Trigger Trigger { get; set; }
    
    public Transition(string id, State source, State destination, Trigger trigger) : base(id)
    {
        this.Source = source;
        this.Destination = destination;
        this.Trigger = trigger;
    }
}