using Becoming.Core.Common.Seedwork.Models;

namespace Becoming.Core.Common.Seedwork.Interfaces;

public interface IDomainEvent
{
    Guid EventId { get; }
    Guid AggregateId { get; }
    DateTime CreatedAt { get; }
    AggregateType AggregateType { get; }
}
