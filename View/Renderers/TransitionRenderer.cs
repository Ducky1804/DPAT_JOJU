using System.Text;
using Model;

namespace View.Diagram;

public class TransitionRenderer : IRenderer<Transition>
{
    public string Render(Transition t)
    {
        StringBuilder builder = new StringBuilder("─── ");
        if (t.Trigger != null)
            builder.Append(t.Trigger.Description);
        
        if (t.Guard.Length > 0)
            builder.Append($"[{t.Guard}]");

        if (t.Action != null)
            builder.Append(" / " + t.Action.Description);

        builder.Append(" ──→ " + t.Destination);
        return builder.ToString();
    }
}