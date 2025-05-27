using Model;

namespace View.Diagram.State;

public class FinalStateRenderer : IRenderer<FinalState>
{
    public string Render(FinalState finalState)
    {
        return "\ud83d\udd34 Initial: " + finalState.Name;
    }
}