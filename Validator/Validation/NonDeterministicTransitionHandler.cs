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
            var duplicateTriggers = group
                .GroupBy(t => new { t.Trigger, t.Guard })
                .Where(g => g.Count() > 1);

            foreach (var dup in duplicateTriggers)
            {
                return false;
            }
        }

        return true;
    }
}