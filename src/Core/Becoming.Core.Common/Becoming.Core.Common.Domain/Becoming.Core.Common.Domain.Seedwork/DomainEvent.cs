﻿using Becoming.Core.Common.Domain.Seedwork.Interfaces;

namespace Becoming.Core.Common.Domain.Seedwork;

public abstract class DomainEvent : IDomainEvent
{
    public Guid EventId { get; init; }
    public Guid AggregateId { get; init; }
    public DateTime CreatedAt { get; init; }
    //TODO: change on guid enumeration
    public AggregateType Type { get; init; }
    public string Message { get => GetMessage(); }

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

    public virtual string GetMessage() =>
        $"{EventId} - Event is created by an aggregate {AggregateId} - {Type} - {CreatedAt:MM/dd/yyyy HH:mm:ss}";
}
