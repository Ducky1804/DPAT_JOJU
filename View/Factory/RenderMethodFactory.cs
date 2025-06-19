using Model;

namespace View.Factory;

public class RenderMethodFactory
{
    private readonly Dictionary<string, RenderVisitor> _renderMethods = new();
    
    public RenderMethodFactory()
    {
        _renderMethods.Add("graph", new GraphRenderVisitor());
        _renderMethods.Add("text", new TextualRenderVisitor());
    }

    public RenderVisitor Create(string type)
    {
        return _renderMethods[type];
    }

    public List<string> GetRenderMethods()
    {
        return _renderMethods.Keys.ToList();
    }
}