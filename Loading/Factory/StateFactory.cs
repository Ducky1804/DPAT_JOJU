using System.Text.RegularExpressions;
using Loading.Builder;
using Model;

namespace Loading.Factory;

public class StateFactory : IFactory<State>
{
    public State Create(Diagram diagram, string input)
    {
        var match = Regex.Match(input, @"^STATE\s+([a-zA-Z]+)\s+([a-zA-Z_]+)\s+""([^""]+)""\s+:\s+(INITIAL|SIMPLE|COMPOUND|FINAL)\s*;");
            var (id, parent, name, type) = (
                match.Groups[1].Value,
                match.Groups[2].Value,
                match.Groups[3].Value,
                match.Groups[4].Value
            );

            StateBuilder builder = new();
            builder.Id = id;
            builder.Name = name;
            builder.Type = type;

            if (parent != "_")
            {
                builder.Parent = diagram.GetState(parent);
            }
        
            return builder.Build();
        
    }
}