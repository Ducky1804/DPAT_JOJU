using Model.Enums;

namespace Model;

public class Transition : Identifiable
{
    public string Source { get; set; }
    public string Destination { get; set; }
    public Trigger? Trigger { get; set; }
    public String? TriggerName { get; set; }
    public String Guard { get; set; }
    public Action? Action { get; set; }
    
    public Transition(string id, string triggerName, string source, string destination, Trigger trigger, string guard) : base(id)
    {
        this.TriggerName = triggerName;
        this.Source = source;
        this.Destination = destination;
        this.Trigger = trigger;
        this.Guard = guard;
    }
    
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}