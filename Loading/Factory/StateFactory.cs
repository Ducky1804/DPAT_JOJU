using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using Loading.Builder;
using Model;

namespace Loading.Factory;

public class StateFactory : IFactory<State>
{
    public State Create(Diagram diagram, string input)
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
        builder.Id = id;
        builder.Name = name;
        builder.Type = type;

        State newState = builder.Build();

        if (parent != "_")
        {
            var parentState = diagram.GetState(parent).ValueOrDefault();
            parentState?.AddChild(newState);
        }
        else
        {
            diagram.States.Add(newState); // toegevoegde methode
        }

        return newState;
    }
}