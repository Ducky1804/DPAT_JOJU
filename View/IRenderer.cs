using Model.State;

namespace View;

public interface IRenderer
{
}
public interface IRenderer<T> : IRenderer
{ 
    String Render(T t);
}