using Model;

namespace Validator.Validation;

public class UnreachableStateHandler : BaseValidationHandler
{
    protected override bool PerformValidation(Diagram diagram)
    {
        List<State> states = diagram.States;
        List<Transition> transitions = diagram.Transitions;
        List<State> reachedStates = new List<State>();

        foreach (Transition transition in transitions)
        {
            State source = diagram.GetState(transition.Source).ValueOrDefault();
            State destination = diagram.GetState(transition.Destination).ValueOrDefault();

            if (!IsStateInList(reachedStates, source)) reachedStates.Add(source);
            if (!IsStateInList(reachedStates, destination)) reachedStates.Add(destination);
        }

        return states.Count <= reachedStates.Count;
    }

    private bool IsStateInList(List<State> states, State state)
    {
        return states.Find(currentState => currentState.Id == state.Id) != null;
    }
}