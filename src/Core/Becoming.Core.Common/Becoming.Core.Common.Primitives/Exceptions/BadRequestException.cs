using Becoming.Core.Common.Seedwork.Models;
using System.Runtime.Serialization;

namespace Becoming.Core.Common.Primitives.Exceptions;

[Serializable]
public sealed class BadRequestException : DomainException
{
    public BadRequestException() : base() { }
    public BadRequestException(string message) : base(message) { }
    public BadRequestException(string message, Exception ex) : base(message, ex) { }
    public BadRequestException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was bad request.") { }
    private BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
