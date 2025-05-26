using System.Text.RegularExpressions;
using Loading.Builder;
using Model;

namespace Loading.Factory;

public class TriggerFactory : IFactory<Trigger>
{
    public Trigger Create(Diagram diagram, string input)
    {
        string pattern = @"TRIGGER\s+(\w+)\s+""([^""]+)"";";
        Match match = Regex.Match(input, pattern);
        
        string id = match.Groups[1].Value;
        string description = match.Groups[2].Value;
        
        return new TriggerBuilder()
            .SetId(id)
            .SetDescription(description)
            .Build();
    }
}