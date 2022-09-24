using Becoming.Core.Common.Infrastructure.Persistence;
using Becoming.Core.Common.Infrastructure.Persistence.Constants;
using Becoming.Core.TaskManager.Infrastructure.Configurations;
using Becoming.Core.TaskManager.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Becoming.Core.TaskManager.Infrastructure.Persistence;

public abstract class TaskManagerContext : BaseContext
{
    protected TaskManagerContext(DbContextOptions options) : base(options) { }

    public DbSet<TaskManagerSaveModel> TaskManagers { get; set; } = null!;
    public DbSet<SummaryTaskSaveModel> SummaryTasks { get; set; } = null!;
    public DbSet<SubtaskSaveModel> Subtasks { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema(DatebaseSettingConstants.TaskManagerSchemaName);

        builder.ApplyConfiguration(new TaskManagerSaveModelConfiguration());
        builder.ApplyConfiguration(new SummaryTaskSaveModelConfiguration());
        builder.ApplyConfiguration(new SubtaskSaveModelConfiguration());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}