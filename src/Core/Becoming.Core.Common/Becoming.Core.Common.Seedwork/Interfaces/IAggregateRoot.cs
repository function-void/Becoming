using Becoming.Core.Common.Seedwork.Models;
using System.Collections.Concurrent;

namespace Becoming.Core.Common.Seedwork.Interfaces;

public interface IAggregateRoot
{
    AggregateType RootType { get; }
    IProducerConsumerCollection<IDomainEvent> DomainEvents { get; }
}
