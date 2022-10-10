﻿using Becoming.Core.TaskManager.Domain.Models;

namespace Becoming.Core.TaskManager.Domain.Repositories;

public interface ITaskManagerRepository
{
    Task<Guid> EmbodyAsync(TaskManagerAggregate aggr, CancellationToken cancellationToken = default);
}