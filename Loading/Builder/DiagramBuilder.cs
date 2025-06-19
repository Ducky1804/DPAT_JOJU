using Model;
using Model.Enums;
using Model.State;
using Model.Utils;
using Action = Model.Action;

namespace Loading.Builder;

public class DiagramBuilder(string name) : IBuilder<Diagram>
{
    private List<State>  _states = new();
    private List<Action> _actions = new();
    private List<Trigger> _triggers = new();
    private List<Transition> _transitions = new();

    public void AddState(State state)
    {
        _states.Add(state);
    }

    public void AddAction(Action action)
    {
        _actions.Add(action);
    }

    public void AddTrigger(Trigger trigger)
    {
        _triggers.Add(trigger);
    }

    public void AddTransition(Transition transition)
    {
        _transitions.Add(transition);
    }
    
    public Diagram Build()
    {
        Diagram diagram = new Diagram()
        {
            Name = name
        };
        
        foreach(var state in _states)
            ApplyState(diagram, state);
        
        foreach(var trigger in _triggers)
            ApplyTrigger(diagram, trigger);
        
        foreach (var transition in _transitions)
            ApplyTransition(diagram, transition);
        
        foreach(var action in _actions) 
            ApplyAction(diagram, action);
        
        return diagram;
    }

    private void ApplyState(Diagram diagram, State state)
    {
        string parent = state.Parent;
        if (parent != "_")
        {
            var parentState = diagram.GetState(parent).ValueOrDefault();
            parentState?.AddChild(state);
        }
        else
        {
            diagram.States.Add(state);
        }

    }

    private void ApplyTrigger(Diagram diagram, Trigger trigger)
    {
        diagram.Triggers.Add(trigger);
    }

    private void ApplyAction(Diagram diagram, Action action)
    {
        Maybe<State> maybeState = diagram.GetState(action.Id);
        if (maybeState.HasValue)
        {
            if (action.Type == ActionType.EntryAction)
                maybeState.ValueOrDefault().OnEntry = action;
                                
            if(action.Type == ActionType.ExitAction)        
                maybeState.ValueOrDefault().OnExit = action;

            if (action.Type == ActionType.DoAction)
                maybeState.ValueOrDefault().OnDo = action;
        }

        if (action.Type == ActionType.TransitionAction)
        {
            string transitionId = action.Id;
            Maybe<Transition> maybeTransition = diagram.GetTransition(transitionId);
            
            if (maybeTransition.HasValue)
            {
                maybeTransition.ValueOrDefault().Action = action;
            }
        }
    }

    private void ApplyTransition(Diagram diagram, Transition transition)
    {
        Maybe<State> maybeState = diagram.GetState(transition.Source);

        if (maybeState.HasValue)
        {
            maybeState.ValueOrDefault().Transitions.Add(transition);

            String? triggerName = transition.TriggerName;
            if (!string.IsNullOrEmpty(triggerName))
            {
                Maybe<Trigger> trigger = string.IsNullOrEmpty(triggerName) ? Maybe<Trigger>.None() : diagram.GetTrigger(triggerName);
                if (trigger.HasValue)
                    transition.Trigger = trigger.ValueOrDefault();
            }
        }
    }
}