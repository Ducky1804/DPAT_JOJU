using Model;

namespace Validator.Validation;

public interface IValidationHandler
{
    IValidationHandler SetNext(IValidationHandler handler);
    bool Handle(Diagram diagram);
}