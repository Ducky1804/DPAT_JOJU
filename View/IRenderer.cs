namespace View;

public interface IRenderer<T>
{ 
    String Render(T t);
}