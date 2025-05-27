namespace View;

public class Menu
{
    public String Title { get; set; }
    public ConsoleColor Color { get; set; }
}

public abstract class MenuRenderer : IRenderer<Menu>
{
    private Menu _menu;
    
    protected MenuRenderer(string title)
    {
        _menu = new Menu()
        {
            Title = title,
        };
    }

    public string Render()
    {
        return this.Render(_menu);
    }

    public string Render(Menu t)
    {
        return t.Title;
    }
}