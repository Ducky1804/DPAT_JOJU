using System.Runtime.InteropServices.JavaScript;
using Model;
using Model.State;
using Validator.Exceptions;

namespace Validator.Validation;

public class UnreachableStateHandler : BaseValidationHandler
{
    protected override bool PerformValidation(Diagram diagram)
    {
        List<State> allStates = GetAllStates(diagram.States);
        List<Transition> transitions = diagram.Transitions;
        List<State> reachedStates = new();

        foreach (Transition transition in transitions)
        {
            State? source = diagram.GetState(transition.Source).ValueOrDefault();
            State? destination = diagram.GetState(transition.Destination).ValueOrDefault();

            if (source != null && !IsStateInList(reachedStates, source))
                reachedStates.Add(source);

            if (destination != null && !IsStateInList(reachedStates, destination))
                reachedStates.Add(destination);
        }

        bool hasUnreachableStates = allStates.Count > reachedStates.Count;

        if (hasUnreachableStates)
            throw new ValidationException("Diagram has unreachable states!");

        return true;
    }

    private bool IsStateInList(List<State> states, State state)
    {
        return states.Any(s => s.Id == state.Id);
    }

    private List<State> GetAllStates(List<State> diagramStates)
    {
        List<State> result = new();

        void Traverse(State state)
        {
            result.Add(state);
            foreach (var child in state.Children)
            {
                Traverse(child);
            }
        }

        foreach (var state in diagramStates)
        {
            Traverse(state);
        }

        return result;
    }
}