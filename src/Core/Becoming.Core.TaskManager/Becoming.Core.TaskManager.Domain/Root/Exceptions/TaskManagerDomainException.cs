using Becoming.Core.Common.Domain.Seedwork;

namespace Becoming.Core.TaskManager.Domain.Root.Exceptions;

[Serializable]
public sealed class TaskManagerDomainException : DomainException
{
    public TaskManagerDomainException() { }
    public TaskManagerDomainException(string message) : base(message) { }
    public TaskManagerDomainException(string message, Exception innerException) : base(message, innerException) { }
}
