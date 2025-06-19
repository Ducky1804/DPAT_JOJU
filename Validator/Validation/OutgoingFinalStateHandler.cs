using Model;
using Model.State;
using Model.Utils;
using Validator.Exceptions;

namespace Validator.Validation;

public class OutgoingFinalStateHandler : BaseValidationHandler
{
    protected override bool PerformValidation(Diagram diagram)
    {
        foreach (var diagramState in diagram.States)
        {
            foreach (var state in GetAllSubStates(diagramState))
            {
                if (state is FinalState && (state.Children.Count != 0 || state.Transitions.Count != 0))
                    throw new ValidationException("Final states cannot have outgoing transitions!");
            }
        }

        return true;
    }
    
    private List<State> GetAllSubStates(State state)
    {
        var result = new List<State> { state };

        foreach (var child in state.Children)
        {
            result.AddRange(GetAllSubStates(child));
        }

        return result;
    }

}