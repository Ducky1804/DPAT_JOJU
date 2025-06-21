using System.Text.RegularExpressions;
using Loading.Builder;
using Model;
using Action = Model.Action;

namespace Loading.Factory;

public class ActionFactory : IFactory<Action>
{
    public Action Create(string input)
    {
        Regex actionRegex = new Regex(
            @"^ACTION\s+([a-zA-Z_][a-zA-Z0-9_]*)\s+""([^""]*)""\s*:\s*([a-zA-Z_][a-zA-Z0-9_]*)\s*;$",
            RegexOptions.Compiled);
        var match = actionRegex.Match(input);

        if (!match.Success)
        {
            throw new ArgumentException($"Ongeldig ACTION statement: {input}");
        }

        string id = match.Groups[1].Value;
        string description = match.Groups[2].Value;
        string type = match.Groups[3].Value;

        return new ActionBuilder()
            .SetId(id)
            .SetType(type)
            .SetDescription(description)
            .Build();
    }
}