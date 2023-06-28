using System.Collections.Concurrent;

namespace Becoming.Core.Common.Domain.Seedwork.Interfaces;

public interface IAggregateRoot
{
    AggregateType RootType { get; }
    IProducerConsumerCollection<IDomainEvent> DomainEvents { get; }
}
