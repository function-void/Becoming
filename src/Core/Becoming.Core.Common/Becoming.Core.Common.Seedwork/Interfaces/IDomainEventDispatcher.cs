namespace Becoming.Core.Common.Seedwork.Interfaces;

public interface IDomainEventDispatcher
{
    Task Dispatch(IDomainEvent devent);
}
