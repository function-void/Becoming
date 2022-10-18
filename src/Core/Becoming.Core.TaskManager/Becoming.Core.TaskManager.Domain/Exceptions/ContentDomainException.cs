using Becoming.Core.Common.Seedwork.Models;
using System.Runtime.Serialization;

namespace Becoming.Core.TaskManager.Domain.Exceptions;

[Serializable]
public sealed class ContentDomainException : DomainException
{
    public ContentDomainException() : base() { }
    public ContentDomainException(string message) : base(message) { }
    public ContentDomainException(string message, Exception innerException) : base(message, innerException) { }
    private ContentDomainException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
    }
}