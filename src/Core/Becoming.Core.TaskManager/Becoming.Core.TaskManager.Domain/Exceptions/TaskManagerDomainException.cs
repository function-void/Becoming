using Becoming.Core.Common.Domain.Seedwork;
using System.Runtime.Serialization;

namespace Becoming.Core.TaskManager.Domain.Exceptions;

[Serializable]
public sealed class TaskManagerDomainException : DomainException
{
    public TaskManagerDomainException() : base() { }
    public TaskManagerDomainException(string message) : base(message) { }
    public TaskManagerDomainException(string message, Exception innerException) : base(message, innerException) { }
    private TaskManagerDomainException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
    }
}
