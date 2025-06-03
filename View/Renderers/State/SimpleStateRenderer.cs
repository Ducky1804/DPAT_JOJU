using Model;
using View.Diagram.Action;
using View.Utils;

namespace View.Diagram.State;

public class SimpleStateRenderer : IRenderer<SimpleState>
{
    public string Render(SimpleState state)
    {
        string? description = null;

        if (state.OnEntry != null)
            description = new ActionRenderer().Render(state.OnEntry);

        if (state.OnExit != null)
            description += "\r\n" + new ActionRenderer().Render(state.OnExit);

        List<string> content = new Rectangle().DrawConsoleRectangle("\ud83d\udccd " + state.Name, description);
        
        foreach (var trans in state.Transitions)
        {
            content.Add(new TransitionRenderer().Render(trans));
        }
        
        return String.Join("\r\n", content);
    }
}