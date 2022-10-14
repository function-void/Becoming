using Becoming.Core.Common.Seedwork.Models;

namespace Becoming.Core.TaskManager.Domain.Events;

public sealed class AddTaskManagerEvent : DomainEvent
{
    public AddTaskManagerEvent(
        Guid eventId,
        Guid aggregateId,
        DateTime createAt,
        AggregateType type = AggregateType.TaskManager)
        : base(eventId, aggregateId, type, createAt)
    {
    }
}
