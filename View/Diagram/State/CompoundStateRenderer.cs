using Model;

namespace View.Diagram.State;

public class CompoundStateRenderer : IRenderer<CompoundState>
{
    public string Render(CompoundState t)
    {
        return "Compound: " + t.Name + "                                                         ";
    }
}