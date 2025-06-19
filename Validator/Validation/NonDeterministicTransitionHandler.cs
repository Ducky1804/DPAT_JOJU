using Model;
using Validator.Exceptions;

namespace Validator.Validation;

public class NonDeterministicTransitionHandler : BaseValidationHandler
{
    protected override bool PerformValidation(Diagram diagram)
    {
        var allTransitions = diagram.States
            .SelectMany(state =>
                state.Transitions.Select(t => new
                {
                    Source = state.Id,
                    TriggerId = t.Trigger?.Id?.Trim().ToLowerInvariant() ?? "",
                    GuardKey = string.IsNullOrWhiteSpace(t.Guard) ? "true" : t.Guard.Trim().ToLowerInvariant()
                })
            );

        var transitionsBySource = allTransitions
            .GroupBy(t => t.Source);

        foreach (var group in transitionsBySource)
        {
            var seen = new HashSet<(string triggerId, string guardKey)>();

            foreach (var t in group)
            {
                var key = (t.TriggerId, t.GuardKey);

                if (!seen.Add(key))
                {
                    throw new ValidationException(
                        $"Non-deterministic transitions found in state '{t.Source}' with trigger '{t.TriggerId}' and guard '{t.GuardKey}'"
                    );
                }
            }
        }

        return true;
    }
}