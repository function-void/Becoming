namespace Becoming.Core.Common.Primitives.Exceptions;

[Serializable]
public sealed class UnauthorizedException : ApplicationException
{
    public UnauthorizedException() : base() { }

    public UnauthorizedException(string message) : base(message) { }

    public UnauthorizedException(string message, Exception ex) : base(message, ex) { }
}