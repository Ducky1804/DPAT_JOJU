using System.Text.RegularExpressions;
using Loading.Builder;
using Model;
using Model.Utils;

namespace Loading.Factory;

public class TransitionFactory : IFactory<Transition>
{
    public Transition Create(Diagram diagram, string input)
    {
        string pattern = @"^TRANSITION\s+" +
                         @"(?<id>\S+)\s+" +
                         @"(?<source>\S+)\s*->\s*(?<destination>\S+)" +
                         @"(?:\s+(?<trigger>\S+))?" +        // optioneel: spatie + trigger
                         @"\s+""(?<guard>[^""]*)""\s*;" +    // verplicht: spatie + guard + puntkomma
                         @"$";

        var match = Regex.Match(input, pattern);

        if (!match.Success)
        {
            throw new ArgumentException("Input does not match expected TRANSITION format: " + input);
        }

        string id = match.Groups["id"].Value;
        string source = match.Groups["source"].Value;
        string destination = match.Groups["destination"].Value;

        string triggerName = match.Groups["trigger"].Success ? match.Groups["trigger"].Value : null;
        Maybe<Trigger> trigger = string.IsNullOrEmpty(triggerName) ? Maybe<Trigger>.None() : diagram.GetTrigger(triggerName);

        string guard = match.Groups["guard"].Value;

        return new TransitionBuilder()
            .SetId(id)
            .SetSource(source)
            .SetDestination(destination)
            .SetTrigger(trigger.ValueOrDefault())
            .SetGuard(guard)
            .Build();
    }
}