using Hangfire;
using System.Transactions;
using Becoming.Core.Common.Application.Concept;
using Becoming.Core.Common.Application.Concept.Models;
using Becoming.Core.Common.Domain.Seedwork;
using Becoming.Core.Common.Domain.Seedwork.Interfaces;
using System.Collections.Concurrent;

namespace Becoming.Core.Common.Infrastructure.Hangfire.Services;

public class Projector : IProjector
{
    public void Enqueue(ICommand command)
    {
        var client = new BackgroundJobClient();
        client.Enqueue<MediatorHangfireBridge>(bridge => bridge.Send(command));
    }

    public void Enqueue(IEvent @event)
    {
        var client = new BackgroundJobClient();
        client.Enqueue<MediatorHangfireBridge>(bridge => bridge.Publish(@event.GetMessage(), @event));
    }

    public void DispatchEvents(AggregateRoot root)
    {
        using TransactionScope transaction = new(
            TransactionScopeOption.Required,
            new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted },
            TransactionScopeAsyncFlowOption.Enabled);

        var queue = (ConcurrentQueue<IDomainEvent>)root.DomainEvents;

        while (queue.TryDequeue(out IDomainEvent? @event))
        {
            Enqueue((IEvent)@event);
        }

        transaction.Complete();
    }
}
