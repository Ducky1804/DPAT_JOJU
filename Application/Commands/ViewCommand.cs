using Model;
using View.Diagram;
using View.Printer;
using View.Utils;

namespace DPAT_JOJU.Commands;

public class ViewCommand(Diagram diagram) : ICommand<Boolean>
{
    public Boolean Execute()
    {
        string content = new StateDiagramRenderer().Render(diagram);
        IPrinter printer = new BoxedContentPrinter(ConsoleColor.Blue);
        printer.Print(content);
        return true;
    }
}