using Model;
using Validator;

namespace DPAT_JOJU.Commands;

public class ValidateCommand(Diagram diagram) : ICommand<Boolean>
{
    public Boolean Execute()
    {
        return new ValidationFacade().ValidateDiagram(diagram);
    }
}