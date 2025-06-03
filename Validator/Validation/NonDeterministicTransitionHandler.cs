using Model;
using Validator.Exceptions;

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
                .GroupBy(t => new
                {
                    Trigger = (t.Trigger?.Description ?? "").Trim().ToLowerInvariant(),
                    Guard = (t.Guard ?? "").Trim().ToLowerInvariant()
                })
                .Where(g => g.Count() > 1);

            foreach (var dup in duplicateTriggers)
            {
                throw new ValidationException(
                    $"Non-deterministic transitions found in state '{group.Key}' with trigger '{dup.Key.Trigger}' and guard '{dup.Key.Guard}'"
                );
            }
        }

        return true;
    }
}