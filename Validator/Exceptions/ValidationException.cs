namespace Validator.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(string message) : base("A validation error occurred: " + message)
    {
    }
}