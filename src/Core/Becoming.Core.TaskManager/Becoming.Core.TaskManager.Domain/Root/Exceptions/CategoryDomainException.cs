using Becoming.Core.Common.Domain.Seedwork;

namespace Becoming.Core.TaskManager.Domain.Root.Exceptions;

[Serializable]
public sealed class CategoryDomainException : DomainException
{
    public CategoryDomainException() : base() { }
    public CategoryDomainException(string message) : base(message) { }
    public CategoryDomainException(string message, Exception innerException) : base(message, innerException) { }
}