﻿using Becoming.Core.Common.Application.Concept;
using Becoming.Core.TaskManager.Domain.Repositories;

namespace Becoming.Core.TaskManager.Application.Queries.Get;

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