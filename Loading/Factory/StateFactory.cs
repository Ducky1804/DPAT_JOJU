using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using Loading.Builder;
using Model;
using Model.State;

namespace Loading.Factory;

public class StateFactory : IFactory<State>
{
    public State Create(string input)
    {
        var match = Regex.Match(input, @"^STATE\s+(\w+)\s+(\w+)\s+""(.*?)""\s+:\s+(\w+);");

        if (!match.Success)
        {
            throw new ArgumentException($"Input is not a valid STATE line: {input}");
        }

        var (id, parent, name, type) = (
            match.Groups[1].Value,
            match.Groups[2].Value,
            match.Groups[3].Value,
            match.Groups[4].Value
        );

        StateBuilder builder = new();
        builder.SetId(id)
            .SetName(name)
            .SetParent(parent)
            .SetType(type);

        return builder.Build();
    }
}