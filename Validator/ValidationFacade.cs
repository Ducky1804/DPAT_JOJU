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
            .SetNext(new UnreachableStateHandler())
            .SetNext(new NonDeterministicTransitionHandler());
    }

    public bool ValidateDiagram(Diagram diagram)
    {
        return _handler.Handle(diagram);
    }
}