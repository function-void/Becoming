namespace Becoming.Core.Common.Primitives.Exceptions;

public sealed class ForbiddenAccessException : ApplicationException
{
    public ForbiddenAccessException() : base() { }

    public ForbiddenAccessException(string message) : base(message){}

    public ForbiddenAccessException(string message, Exception ex) : base(message, ex){}
}