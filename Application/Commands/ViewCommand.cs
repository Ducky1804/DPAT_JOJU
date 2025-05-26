using Model;

namespace DPAT_JOJU.Commands;

public class ViewCommand(Diagram diagram) : ICommand<Boolean>
{
    public Boolean Execute()
    {
        return true;
    }
}