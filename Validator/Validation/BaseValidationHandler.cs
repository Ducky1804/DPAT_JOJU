using Model;

namespace Validator.Validation;

public abstract class BaseValidationHandler : IValidationHandler
{
    protected IValidationHandler _next;
    
    public IValidationHandler SetNext(IValidationHandler handler)
    {
        _next = handler;
        return handler;
    }

    public bool Handle(Diagram diagram)
    {
        if (!PerformValidation(diagram))
        {
            return false;
        }

        return _next?.Handle(diagram) ?? true;
    }

    protected abstract bool PerformValidation(Diagram diagram);
}