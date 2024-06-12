using MediatR;
using Becoming.Core.Common.Application.Concept;
using Becoming.Core.Common.Domain.Seedwork;

namespace Becoming.Core.TaskManager.Application.Root.Commands.Create;

public sealed class AddedTaskManagerEvent : DomainEvent, IEvent
{
    public AddedTaskManagerEvent(
        Guid eventId,
        Guid aggregateId) : base(eventId, aggregateId, AggregateType.TaskManager) { }
}