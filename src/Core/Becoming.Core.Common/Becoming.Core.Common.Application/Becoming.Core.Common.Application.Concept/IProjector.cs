using Becoming.Core.Common.Domain.Seedwork;

namespace Becoming.Core.Common.Application.Concept;

public interface IProjector
{
    public void Enqueue(ICommand command);
    public void Enqueue(IEvent command);
    void DispatchEvents(AggregateRoot root);
}
