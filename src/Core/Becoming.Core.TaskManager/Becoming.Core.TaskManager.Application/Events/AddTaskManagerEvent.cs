using Becoming.Core.Common.Application.Concept;
using Becoming.Core.Common.Domain.Seedwork;
using MediatR;

namespace Becoming.Core.TaskManager.Application.Events;

public sealed class AddTaskManagerEvent : DomainEvent, IEvent
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

public sealed class AddTaskManagerEventHandler : INotificationHandler<AddTaskManagerEvent>
{
    public Task Handle(AddTaskManagerEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
