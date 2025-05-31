using System.Runtime;
using Model;
using Model.State;
using View.Diagram.State;

namespace View.Factory;

public class RenderFactory
{
    private static RenderFactory? _instance = null;

    public static RenderFactory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new RenderFactory();
            }

            return _instance;
        }
    }

    private Dictionary<Type, IRenderer> _renderers = new();

    private RenderFactory()
    {
        _renderers.Add(typeof(SimpleState), new SimpleStateRenderer());
        _renderers.Add(typeof(FinalState), new FinalStateRenderer());
        _renderers.Add(typeof(InitialState), new InitialStateRenderer());
        _renderers.Add(typeof(CompoundState), new CompoundStateRenderer());
    }

    public IRenderer<T> CreateStateRenderer<T>(T state)
    {
        Type type = state.GetType();

        if (type == typeof(State))
            type = GetConcreteType(state);
        
        if (_renderers.TryGetValue(type, out var renderer))
        {
            if (renderer is IRenderer<T> typedRenderer)
            {
                return typedRenderer;
            }

            throw new InvalidCastException($"Registered renderer does not match type IRenderer<{typeof(T).Name}>");
        }

        throw new KeyNotFoundException($"No renderer registered for type {state.GetType().Name}");
    }

    private Type GetConcreteType(State state)
    {
    }
}