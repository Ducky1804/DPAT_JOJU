using Model;
using Model.State;
using View.Diagram.State;

namespace View.Factory;

public class RenderFactory
{
    private Dictionary<Type, IRenderer> _renderers = new();
    
    public RenderFactory()
    {
        _renderers.Add(typeof(FinalState), new FinalStateRenderer());
        _renderers.Add(typeof(InitialState), new InitialStateRenderer());
        _renderers.Add(typeof(CompoundState), new CompoundStateRenderer());
        _renderers.Add(typeof(SimpleState), new SimpleStateRenderer());
    }
    
    public IRenderer<T> CreateStateRenderer<T>(T state) where T : State
    {
        var renderer = _renderers[state.GetType()] as IRenderer<T>;
        if (renderer == null) throw new Exception("Renderer not found or incorrect type!");
        return renderer;
    }
}