using Becoming.Core.Common.Abstractions.CQRS.Interfaces;
using Becoming.Core.TaskManager.Domain.Repositories;

namespace Becoming.Core.TaskManager.Application.Queries.GetTaskManager;

public sealed record class GetTaskManagerByIdQuery(Guid Id) : IQuery<TaskManagerResponse>;

sealed class GetTaskManagerQueryHandler : IQueryHandler<GetTaskManagerByIdQuery, TaskManagerResponse>
{
    private readonly ITaskManagerRepository _repository;

    public GetTaskManagerQueryHandler(
        ITaskManagerRepository repository
        )
    {
        _repository = repository;
    }

    public Task<TaskManagerResponse> Handle(GetTaskManagerByIdQuery query, CancellationToken cancellationToken)
    {
        return Task.FromResult(new TaskManagerResponse(query.Id, "Title") { CategoryName = "CategoryName" });
    }
}