using Becoming.Core.Common.Seedwork.Interfaces;

namespace Becoming.Core.Common.Seedwork.Models;

public abstract class DomainEvent : IDomainEvent
{
    public Guid EventId { get; init; }
    public Guid AggregateId { get; init; }
    public DateTime CreatedAt { get; init; }
    //TODO: change on guid enumeration
    public AggregateType Type { get; init; }

    protected DomainEvent(
        Guid eventId,
        Guid aggregateId,
        AggregateType type,
        DateTime createAt)
    {
        EventId = eventId;
        AggregateId = aggregateId;
        Type = type;
        CreatedAt = createAt;
    }

    public override string ToString()
        => $"Event with {EventId} ID is created by an aggregate {AggregateId}-{Type} - {CreatedAt:MM/dd/yyyy HH:mm:ss}";
}
