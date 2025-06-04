using Model;
using View;
using View.Diagram;
using View.Printer;
using View.Utils;

namespace DPAT_JOJU.Commands;

public class ViewCommand(Diagram diagram, RenderVisitor renderMethod) : ICommand<Boolean>
{
    public Boolean Execute()
    {
        new StateDiagramRenderer().Render(diagram, renderMethod);
        return true;
    }
}