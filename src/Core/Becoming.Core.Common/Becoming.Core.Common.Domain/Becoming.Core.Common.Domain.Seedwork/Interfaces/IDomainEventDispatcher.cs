namespace Becoming.Core.Common.Domain.Seedwork.Interfaces;

public interface IDomainEventDispatcher
{
    Task Dispatch(IDomainEvent devent);
}
