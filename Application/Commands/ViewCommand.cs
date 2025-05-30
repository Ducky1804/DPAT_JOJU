using Model;
using View.Diagram;
using View.Printer;
using View.Utils;

namespace DPAT_JOJU.Commands;

public class ViewCommand(Diagram diagram) : ICommand<Boolean>
{
    public Boolean Execute()
    {
        new StateDiagramRenderer().Render(diagram);
        return true;
    }
}