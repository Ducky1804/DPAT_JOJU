using Loading.Factory;
using Model;
using System.Reflection;
using Loading.Reader;
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
        var diagram = new Diagram()
        {
            Name = name,
        };

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
                var createMethod = factoryType.GetMethod("Create", new[] { typeof(Diagram), typeof(string) });
                if (createMethod == null)
                    throw new InvalidOperationException(
                        $"Factory {factoryType.Name} heeft geen juiste Create methode.");

                var createdObject = createMethod.Invoke(factoryInstance, new object[] { diagram, line });
                
                if (createdObject is Trigger trigger)
                {
                    diagram.Triggers.Add(trigger);
                }

                if (createdObject is Action action)
                {
                    Maybe<State> maybeState = diagram.GetState(action.Id);
                    if (maybeState.HasValue)
                    {
                        if (action.Type == "ENTRY_ACTION")
                            maybeState.ValueOrDefault().OnEntry = action;
                                
                        if(action.Type == "EXIT_ACTION")        
                            maybeState.ValueOrDefault().OnExit = action;
                    }
                }

                if (createdObject is Transition transition)
                {
                    Maybe<State> maybeState = diagram.GetState(transition.Source);
                    
                    if (maybeState.HasValue)
                        maybeState.ValueOrDefault().Transitions.Add(transition);
                }
            }
        }

        return diagram;
    }

    public IFactory<T> CreateFactory<T>(string key)
    {
        return null;
    }
}