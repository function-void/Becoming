namespace Becoming.Core.Common.Primitives.Exceptions;

[Serializable]
public sealed class ConflictException : ApplicationException
{
    public ConflictException() : base() { }
    public ConflictException(string message) : base(message) { }
    public ConflictException(string message, Exception ex) : base(message, ex) { }
}
