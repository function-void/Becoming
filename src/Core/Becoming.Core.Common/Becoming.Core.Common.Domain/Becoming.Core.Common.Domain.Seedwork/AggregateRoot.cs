using Becoming.Core.Common.Domain.Seedwork.Interfaces;
using System.Collections.Concurrent;

namespace Becoming.Core.Common.Domain.Seedwork;

public abstract class AggregateRoot : Entity, IAggregateRoot
{
    private readonly ConcurrentQueue<IDomainEvent> _domainEvents = new();

    protected AggregateRoot(Guid id) : base(id)
    {
        FactoryKey = nameof(AggregateRoot);
    }

    protected AggregateRoot(Guid id, string factoryKey) : base(id)
    {
        FactoryKey = factoryKey;
    }

    protected string FactoryKey { get; private init; }

    public IProducerConsumerCollection<IDomainEvent> DomainEvents => _domainEvents;

    public virtual AggregateType RootType => AggregateType.NoDefinition;

    public void PublishDomainEvent(IDomainEvent @event) => _domainEvents.Enqueue(@event);

    public void ClearDomainEvents() => _domainEvents.Clear();
}