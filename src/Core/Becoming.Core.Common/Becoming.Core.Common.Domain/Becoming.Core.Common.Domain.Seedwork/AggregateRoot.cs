using Becoming.Core.Common.Domain.Seedwork.Interfaces;
using System.Collections.Concurrent;

namespace Becoming.Core.Common.Domain.Seedwork;

public abstract class AggregateRoot : Entity, IAggregateRoot
{
    private readonly ConcurrentQueue<IDomainEvent> _domainEvents = new();

    protected AggregateRoot(Guid id) : base(id) { }

    public IProducerConsumerCollection<IDomainEvent> DomainEvents => _domainEvents;

    public virtual AggregateType RootType => AggregateType.NoDefinition;

    public void PublishDomainEvent(IDomainEvent @event) => _domainEvents.Enqueue(@event);

    public void ClearDomainEvents() => _domainEvents.Clear();
}