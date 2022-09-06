using System.Runtime.Serialization;

namespace Becoming.Core.Common.Primitives.Exceptions;

public abstract class ApplicationException : Exception
{
    protected ApplicationException() : this(string.Empty) { }
    protected ApplicationException(string message) : base(message) { }
    protected ApplicationException(string message, Exception ex) : base(message, ex) { }
    protected ApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
