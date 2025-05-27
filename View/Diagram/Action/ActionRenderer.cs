namespace View.Diagram.Action;

public class ActionRenderer : IRenderer<Model.Action>
{
    public string Render(Model.Action t)
    {
        return t.Type + "/" + t.Description + "";
    }
}