using System.Runtime;
using Model;
using Model.State;
using View.Diagram.State;

namespace View.Factory;

public class RenderFactory
{
    private static readonly RenderFactory _instance = new RenderFactory();
    public static RenderFactory Instance => _instance;

    private Dictionary<Type, IRenderer> _renderers = new();

    private RenderFactory()
    {
        _renderers.Add(typeof(SimpleState), new SimpleStateRenderer());
        _renderers.Add(typeof(FinalState), new FinalStateRenderer());
        _renderers.Add(typeof(InitialState), new InitialStateRenderer());
        _renderers.Add(typeof(CompoundState), new CompoundStateRenderer());
    }

    public IRenderer<T>? CreateStateRenderer<T>(T t, Type type)
    {
        if (_renderers.TryGetValue(type, out var renderer))
        {
            if (renderer is IRenderer<T> typedRenderer)
            {
                return typedRenderer;
            }

            return (IRenderer<T>)renderer;
        }

        return null;
    }

}