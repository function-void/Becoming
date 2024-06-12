using Becoming.Core.Common.Application.Concept;
using Becoming.Core.TaskManager.Application.Root.Queries;
using Becoming.Core.TaskManager.Infrastructure.Persistence;

namespace Becoming.Core.TaskManager.Infrastructure.Queries;

sealed class GetTaskManagerQueryHandler : IQueryHandler<GetTaskManagerByIdQuery, TaskManagerResponse>
{
    private readonly TaskManagerContext _context;

    public GetTaskManagerQueryHandler(TaskManagerContext context)
    {
        _context = context;
    }

    public Task<TaskManagerResponse> Handle(GetTaskManagerByIdQuery query, CancellationToken cancellationToken)
    {
        return Task.FromResult(new TaskManagerResponse(query.Id, "Title") { CategoryName = "CategoryName" });
    }
}
