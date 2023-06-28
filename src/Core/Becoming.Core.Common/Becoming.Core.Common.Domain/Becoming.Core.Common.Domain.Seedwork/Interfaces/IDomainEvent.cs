
namespace Becoming.Core.Common.Domain.Seedwork.Interfaces;

public interface IDomainEvent
{
    Guid EventId { get; init; }
    Guid AggregateId { get; init; }
    DateTime CreatedAt { get; init; }
    //TODO: change on guid enumeration
    AggregateType Type { get; init; }
    string GetMessage();
}
