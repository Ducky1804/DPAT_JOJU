using Model;
using Validator.Validation;

namespace Validator;

public class ValidationFacade
{
    private IValidationHandler _handler;

    public ValidationFacade()
    {
        _handler = new OutgoingFinalStateHandler();
        _handler
            .SetNext(new NonDeterministicTransitionHandler())
            .SetNext(new UnreachableStateHandler());
    }

    public bool ValidateDiagram(Diagram diagram)
    {
        return true;
        //return _handler.Handle(diagram);
    }
}