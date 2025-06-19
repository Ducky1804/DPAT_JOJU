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

public class FactoryDispatcher
{
    private readonly Dictionary<string, Type> _factories;

    public FactoryDispatcher()
    {
        _factories = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase)
        {
            { "STATE", typeof(StateFactory) },
            { "TRIGGER", typeof(TriggerFactory) },
            { "ACTION", typeof(ActionFactory) },
            { "TRANSITION", typeof(TransitionFactory) },
        };
    }

    public Diagram CreateDiagram(string name, List<string> content)
    {
        DiagramBuilder builder = new DiagramBuilder(name);
        
        foreach (string line in content)
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
}