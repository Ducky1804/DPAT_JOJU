using Model.Utils;

namespace Model;

public class Diagram
{
    public List<State> States { get; set; } = new();
    public List<Trigger> Triggers { get; set; } = new();
    public List<Action> Actions { get; set; } = new();
    public List<Transition> Transitions { get; set; } = new();

    public Maybe<State> GetState(string? identifier)
    {
        if (identifier == null) return Maybe<State>.None();
        
        foreach (var state in States)
        {
            if (state.Id == identifier) return Maybe<State>.Of(state);
        }
        
        return Maybe<State>.None();
    }

    public Maybe<Trigger> GetTrigger(string? identifier)
    {
        if (identifier == null) return Maybe<Trigger>.None();

        foreach (Trigger trigger in Triggers)
        {
            if (trigger.Id == identifier) return Maybe<Trigger>.Of(trigger);
        }
        
        return Maybe<Trigger>.None();
    }
}