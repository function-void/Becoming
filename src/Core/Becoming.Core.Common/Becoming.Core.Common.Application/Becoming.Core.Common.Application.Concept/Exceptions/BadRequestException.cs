using Becoming.Core.Common.Domain.Seedwork;

namespace Becoming.Core.Common.Application.Concept.Exceptions;

[Serializable]
public sealed class BadRequestException : DomainException
{
    public BadRequestException() : this(string.Empty) { }
    public BadRequestException(string message) : base(message) { }
    public BadRequestException(string message, Exception ex) : base(message, ex) { }
    public BadRequestException(string name, object key) : base($"Entity \"{name}\" ({key}) was bad request.") { }
}
