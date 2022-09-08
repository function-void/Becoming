using Becoming.Core.TaskManager.Domain.Models;
using Becoming.Core.TaskManager.Domain.Repositories;
using Becoming.Core.TaskManager.Infrastructure.Persistence;

namespace Becoming.Core.TaskManager.Infrastructure.Repositories;

public sealed class TaskManagerRepository : ITaskManagerRepository
{
    private readonly TaskManagerContext _context;

    public TaskManagerRepository(TaskManagerContext context)
    {
        _context = context;
    }

    #region commands
    public Task<Guid> EmbodyAsync(TaskManagerAggregate aggr, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    #endregion
}
