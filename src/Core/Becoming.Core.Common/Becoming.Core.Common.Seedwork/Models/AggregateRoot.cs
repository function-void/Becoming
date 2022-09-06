using System.Collections.Concurrent;
using Becoming.Core.Common.Seedwork.Interfaces;

namespace Becoming.Core.Common.Seedwork.Models;

public abstract class AggregateRoot : Entity, IAggregateRoot
{
    private readonly ConcurrentQueue<IDomainEvent> _domainEvents = new();

    protected AggregateRoot(Guid id) : base(id)
    {
    }

    public IProducerConsumerCollection<IDomainEvent> DomainEvents => _domainEvents;

    public virtual AggregateType RootType => AggregateType.NoDefinition;

    public void PublishDomainEvent(IDomainEvent @event) => _domainEvents.Enqueue(@event);

    public void ClearDomainEvents() => _domainEvents.Clear();
}
