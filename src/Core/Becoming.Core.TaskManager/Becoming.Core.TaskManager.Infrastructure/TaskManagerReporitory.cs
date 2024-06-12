using Becoming.Core.TaskManager.Domain.Root;
using Becoming.Core.TaskManager.Infrastructure.Persistence.Models;
using Becoming.Core.TaskManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Becoming.Core.TaskManager.Infrastructure;

public sealed class TaskManagerRepository : ITaskManagerRepository
{
    private readonly TaskManagerContext _context;

    public TaskManagerRepository(TaskManagerContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateAsync(TaskManagerRoot aggr, CancellationToken cancellationToken = default)
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

        await _context.TaskManagers.AddAsync(model);

        return model.Id;
    }

    public Task UpdateAsync(TaskManagerRoot aggr)
    {
        throw new NotImplementedException();
    }

    public async Task<TaskManagerRoot> GetByIdAsync(Guid taskManagerId)
    {
        var model = await _context.TaskManagers
            .Include(x => x.SummaryTasks).ThenInclude(x => x.Subtasks)
            .FirstOrDefaultAsync(x => x.Id == taskManagerId);

        return null!;
    }
}
