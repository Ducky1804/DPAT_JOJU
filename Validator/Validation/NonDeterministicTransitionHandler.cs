using Model;

namespace Validator.Validation;

public class NonDeterministicTransitionHandler : BaseValidationHandler
{
    protected override bool PerformValidation(Diagram diagram)
    {
        var transitionsPerSource = diagram.Transitions
            .GroupBy(t => t.Source);

        foreach (var group in transitionsPerSource)
        {
            // Groepeer op trigger binnen dezelfde bronstate
            var duplicateTriggers = group
                .GroupBy(t => t.Trigger)
                .Where(g => g.Count() > 1);

            if (duplicateTriggers.Any())
            {
                return false; // Niet-deterministisch
            }
        }

        return true;
    }


}