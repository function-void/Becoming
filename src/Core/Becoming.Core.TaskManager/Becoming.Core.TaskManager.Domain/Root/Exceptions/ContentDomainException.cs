using Becoming.Core.Common.Domain.Seedwork;

namespace Becoming.Core.TaskManager.Domain.Root.Exceptions;

[Serializable]
public sealed class ContentDomainException : DomainException
{
    public ContentDomainException() : base() { }
    public ContentDomainException(string message) : base(message) { }
    public ContentDomainException(string message, Exception innerException) : base(message, innerException) { }
}