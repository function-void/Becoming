using Becoming.Core.Common.Domain.Seedwork;
using Becoming.Core.Common.Domain.Seedwork.Interfaces;
using System.Collections.Concurrent;

namespace Becoming.Core.Common.Application.Concept;

public static class AggregateRootExtensions
{
    public static void DispatchEvents(this AggregateRoot root, IProjector projector)
    {
        var queue = (ConcurrentQueue<IDomainEvent>)root.DomainEvents;

        while (queue.TryDequeue(out IDomainEvent? @event))
        {
            projector.Enqueue((IEvent)@event);
        }
    }
}
