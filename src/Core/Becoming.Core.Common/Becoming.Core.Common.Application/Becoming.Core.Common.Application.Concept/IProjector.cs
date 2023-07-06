using Becoming.Core.Common.Domain.Seedwork.Interfaces;

namespace Becoming.Core.Common.Application.Concept;

public interface IProjector
{
    public void Enqueue(ICommand commnad);
    public void Enqueue(IEvent commnad);
}
