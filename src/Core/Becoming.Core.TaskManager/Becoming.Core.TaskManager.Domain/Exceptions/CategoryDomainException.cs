using Becoming.Core.Common.Domain.Seedwork;
using System.Runtime.Serialization;

namespace Becoming.Core.TaskManager.Domain.Exceptions;

[Serializable]
public sealed class CategoryDomainException : DomainException
{
    public CategoryDomainException() : base() { }
    public CategoryDomainException(string message) : base(message) { }
    public CategoryDomainException(string message, Exception innerException) : base(message, innerException) { }
    private CategoryDomainException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
    }
}