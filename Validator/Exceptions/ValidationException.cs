﻿namespace Validator.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(string message) : base("An validation error occurred: " + message)
    {
    }
}