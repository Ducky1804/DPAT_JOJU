using View.Utils;

namespace View.Diagram;

public class HeaderRenderer : IRenderer<string>
{
    public string Render(string t)
    {
        Rectangle rectangle = new Rectangle();
        return rectangle.DrawConsoleRectangle(t).ConvertToString();
    }
}