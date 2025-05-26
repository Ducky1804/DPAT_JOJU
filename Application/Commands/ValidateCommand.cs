using Model;

namespace DPAT_JOJU.Commands;

public class ValidateCommand(Diagram diagram) : ICommand<Boolean>
{
    public Boolean Execute()
    {
        return false;
    }
}