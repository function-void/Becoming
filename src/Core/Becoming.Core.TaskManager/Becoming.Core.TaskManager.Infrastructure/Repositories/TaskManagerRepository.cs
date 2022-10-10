﻿using Becoming.Core.Common.Infrastructure.Repositories;
using Becoming.Core.TaskManager.Domain.Models;
using Becoming.Core.TaskManager.Domain.Repositories;
using Becoming.Core.TaskManager.Infrastructure.Models;
using Becoming.Core.TaskManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Storage;

namespace Becoming.Core.TaskManager.Infrastructure.Repositories;

public sealed class TaskManagerRepository : BaseRepository<TaskManagerContext, TaskManagerSaveModel>, ITaskManagerRepository
{
    public TaskManagerRepository(TaskManagerContext context) : base(context) { }

    #region write
    public async Task<Guid> EmbodyAsync(TaskManagerAggregate aggr, CancellationToken cancellationToken = default)
    {
        var model = new TaskManagerSaveModel()
        {
            Id = aggr.Id,
            IsActive = true,
            IsArchive = false,
            Title = aggr.Title,
            Category = new CategoryModel()
            {
                Name = aggr.Category.Name
            }
        };

        _ = await CreateAsync(model, cancellationToken);

        return model.Id;
    }

    public override async Task RequiredRelationUpdateAsync(TaskManagerSaveModel model, Guid targetId, IDbContextTransaction? transaction = default, CancellationToken token = default)
    {
        using var newTransaction = transaction ?? await _context.Database.BeginTransactionAsync(token);

        throw new NotImplementedException();
    }

    public override async Task RequiredRelationUpdateAsync(TaskManagerSaveModel model, Guid targetId, Guid[] spares, IDbContextTransaction? transaction = default, CancellationToken token = default)
    {
        using var newTransaction = transaction ?? await _context.Database.BeginTransactionAsync(token);

        throw new NotImplementedException();
    }

    public override Task<int> UseOriginalUpdateAsync(TaskManagerSaveModel changedDataModel, TaskManagerSaveModel? orinalModel = null, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region read
    #endregion
}