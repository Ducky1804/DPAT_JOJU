using Model;
using Model.State;
using System.Collections.Generic;
using System.Linq;
using Validator.Exceptions;

namespace Validator.Validation;

public class UnreachableStateHandler : BaseValidationHandler
{
    protected override bool PerformValidation(Diagram diagram)
    {
        List<State> states = diagram.States;

        var unreachableStates = states
            .Where(s => s is not CompoundState and not InitialState and not FinalState && !IsReachable(states, s))
            .ToList();

        if (unreachableStates.Any())
        {
            var unreachableIds = string.Join(", ", unreachableStates.Select(s => s.Id));
            throw new ValidationException($"The FSM in this file is invalid. State(s) {unreachableIds} are unreachable");
        }

        return true;
    }

    private bool IsReachable(List<State> allStates, State target)
    {
        var relevantStates = new List<State> { target };
        relevantStates.AddRange(GetParentStates(target, allStates));

        foreach (var state in allStates)
        {
            foreach (var transition in state.Transitions)
            {
                if (relevantStates.Any(rs => rs.Id == transition.Destination))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private List<State> GetParentStates(State state, List<State> allStates)
    {
        var result = new List<State>();
        var current = state;

        while (!string.IsNullOrEmpty(current.Parent))
        {
            var parent = allStates.FirstOrDefault(s => s.Id == current.Parent);
            if (parent == null)
                break;

            result.Add(parent);
            current = parent;
        }

        return result;
    }
}