using Becoming.Core.TaskManager.Domain.Models;

namespace Becoming.Core.TaskManager.Domain.Repositories;

public interface ICommandTaskManagerRepository
{
    Task<Guid> EmbodyAsync(TaskManagerAggregate aggr, CancellationToken cancellationToken = default);

    //Task RequiredRelationUpdate(TaskManagerAggregate model, Guid targetId, IDbContextTransaction? transaction = default, CancellationToken token = default);

    //Task RequiredRelationUpdate(TaskManagerAggregate model, Guid targetId, Guid[] spares, IDbContextTransaction transaction, CancellationToken token = default);
}