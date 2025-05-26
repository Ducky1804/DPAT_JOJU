using Loading.Factory;
using Model;
using System.Reflection;

namespace Loading;

public class AbstractFactory
{
    private readonly Dictionary<string, Type> factories;

    public AbstractFactory()
    {
        factories = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase)
        {
            { "STATE", typeof(StateFactory) }
            // later hier eenvoudig meer toevoegen
        };
    }

    public Diagram CreateDiagram(string content)
    {
        var diagram = new Diagram();

        foreach (string line in content.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
        {
            if (line.StartsWith("#")) 
                continue;

            var tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length == 0)
                continue;

            string keyword = tokens[0].ToUpper();

            if (factories.TryGetValue(keyword, out Type factoryType))
            {
                var factoryInstance = Activator.CreateInstance(factoryType);
                var createMethod = factoryType.GetMethod("Create", new[] { typeof(Diagram), typeof(string) });
                if (createMethod == null) 
                    throw new InvalidOperationException($"Factory {factoryType.Name} heeft geen juiste Create methode.");

                var createdObject = createMethod.Invoke(factoryInstance, new object[] { diagram, line });

                if (createdObject is State state)
                {
                    PrintStateInfo(state);
                    diagram.States.Add(state);
                }
            }
        }

        return diagram;
    }

    private void PrintStateInfo(State state)
    {
        Console.WriteLine($"ID: {state.Id}");
        Console.WriteLine($"Name: {state.Name}");
        Console.WriteLine($"Type: {state.GetType().Name}");
        Console.WriteLine($"Parent: {(state.ParentState != null ? state.ParentState.Name : "No parent")}");
        Console.WriteLine("-=-=-=-=-=-=-=-=-=-");
    }
}
