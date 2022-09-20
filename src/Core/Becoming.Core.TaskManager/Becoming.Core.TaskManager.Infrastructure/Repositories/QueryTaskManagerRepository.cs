using Becoming.Core.TaskManager.Domain.Repositories;
using Becoming.Core.TaskManager.Infrastructure.Persistence;

namespace Becoming.Core.TaskManager.Infrastructure.Repositories;

public class QueryTaskManagerRepository : IQueryTaskManagerRepository
{
    private readonly TaskManagerContext _context;

    public QueryTaskManagerRepository(TaskManagerContext context)
    {
        _context = context;
    }
}
