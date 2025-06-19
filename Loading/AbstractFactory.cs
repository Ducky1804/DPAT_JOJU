using Loading.Factory;
using Model;
using System.Reflection;
using Loading.Builder;
using Loading.Reader;
using Model.Enums;
using Model.State;
using Model.Utils;
using Action = Model.Action;

namespace Loading;

public class AbstractFactory
{
    private readonly Dictionary<string, Type> _factories;
    private readonly IFileReader _reader;

    public AbstractFactory(IFileReader fileReader)
    {
        _reader = fileReader;
        _factories = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase)
        {
            { "STATE", typeof(StateFactory) },
            { "TRIGGER", typeof(TriggerFactory) },
            { "ACTION", typeof(ActionFactory) },
            { "TRANSITION", typeof(TransitionFactory) },
        };
    }

    public Diagram CreateDiagram(string name, string content)
    {
        DiagramBuilder builder = new DiagramBuilder(name);

        List<string> filteredLines = _reader.ReadFile(content);
        foreach (string line in filteredLines)
        {
            var tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length == 0)
                continue;

            string keyword = tokens[0].ToUpper();

            if (_factories.TryGetValue(keyword, out Type factoryType))
            {
                var factoryInstance = Activator.CreateInstance(factoryType);
                var createMethod = factoryType.GetMethod("Create", new[] { typeof(string) });
                if (createMethod == null)
                    throw new InvalidOperationException(
                        $"Factory {factoryType.Name} heeft geen juiste Create methode.");

                var createdObject = createMethod.Invoke(factoryInstance, new object[] { line });
                
                if(createdObject is State state)
                    builder.AddState(state);
                
                if (createdObject is Trigger trigger)
                    builder.AddTrigger(trigger);

                if (createdObject is Action action)
                    builder.AddAction(action);
                
                if(createdObject is Transition transition)
                    builder.AddTransition(transition);
            }
        }

        return builder.Build();
    }

    public IFactory<T> CreateFactory<T>(string key)
    {
        return null;
    }
}