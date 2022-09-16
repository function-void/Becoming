using Becoming.Core.Common.Infrastructure.Repositories;
using Becoming.Core.TaskManager.Domain.Models;
using Becoming.Core.TaskManager.Domain.Repositories;
using Becoming.Core.TaskManager.Infrastructure.Models;
using Becoming.Core.TaskManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Storage;

namespace Becoming.Core.TaskManager.Infrastructure.Repositories;

public sealed class TaskManagerRepository : BaseRepository<TaskManagerContext, TaskManagerSaveModel>, ITaskManagerRepository
{
    public TaskManagerRepository(TaskManagerContext context) : base(context) { }

    #region commands
    public Task<Guid> EmbodyAsync(TaskManagerAggregate aggr, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task RequiredRelationUpdate(TaskManagerAggregate model, Guid targetId, IDbContextTransaction? transaction = default, CancellationToken token = default)
    {
        using var newTransaction = transaction ?? await _context.Database.BeginTransactionAsync(token);

        throw new NotImplementedException();
    }

    public async Task RequiredRelationUpdate(TaskManagerAggregate model, Guid targetId, Guid[] spares, IDbContextTransaction? transaction = default, CancellationToken token = default)
    {
        using var newTransaction = transaction ?? await _context.Database.BeginTransactionAsync(token);

        throw new NotImplementedException();
    }

    public override Task<int> UseOriginalUpdateAsync(TaskManagerSaveModel changedDataModel, TaskManagerSaveModel? orinalModel = null, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
    #endregion
}
