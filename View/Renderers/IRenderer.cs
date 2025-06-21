using Model.State;

namespace View;

public interface IRenderer
{
}
public interface IRenderer<in T> : IRenderer
{ 
    string Render(T t);
}