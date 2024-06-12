using Becoming.Core.TaskManager.Domain.Root;

namespace Becoming.Core.TaskManager.Domain.Root;

public interface ITaskManagerRepository
{
    Task<Guid> CreateAsync(TaskManagerRoot aggr, CancellationToken cancellationToken = default);

    Task<TaskManagerRoot> GetByIdAsync(Guid taskManagerId);

    Task UpdateAsync(TaskManagerRoot aggr);
}