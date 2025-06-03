using Model;
using Model.State;
using Model.Utils;
using Validator.Exceptions;

namespace Validator.Validation;

public class OutgoingFinalStateHandler : BaseValidationHandler
{
    protected override bool PerformValidation(Diagram diagram)
    {
        foreach (var transition in diagram.Transitions)
        {
            Maybe<State> maybeSource = diagram.GetState(transition.Source);
            
            if (!maybeSource.HasValue) continue;

            State maybe = maybeSource.ValueOrDefault();

            if (maybe is FinalState) throw new ValidationException("final state cannot have outgoing transitions!");
        }

        return true;
    }
}