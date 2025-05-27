using Model.Utils;

namespace Model;

public class Diagram
{
    public string Name { get; set; }
    public List<State> States { get; set; } = new();
    public List<Trigger> Triggers { get; set; } = new();
    public List<Transition> Transitions { get; set; } = new();

    public Maybe<State> GetState(string? identifier)
    {
        if (identifier == null) return Maybe<State>.None();

        foreach (var state in States)
        {
            var result = FindStateRecursive(state, identifier);
            if (result.HasValue) return result;
        }

        return Maybe<State>.None();
    }

    private Maybe<State> FindStateRecursive(State state, string identifier)
    {
        if (state.Id == identifier) return Maybe<State>.Of(state);

        foreach (var child in state.Children)
        {
            var result = FindStateRecursive(child, identifier);
            if (result.HasValue) return result;
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