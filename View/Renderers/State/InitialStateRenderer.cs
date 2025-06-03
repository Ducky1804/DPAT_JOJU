using Model;

namespace View.Diagram.State;

public class InitialStateRenderer : IRenderer<InitialState>
{
    public string Render(InitialState initialState)
    {
        return "\ud83d\udfe2 Initial: " + initialState.Name;
    }
}