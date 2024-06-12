using Microsoft.EntityFrameworkCore;
using Becoming.Core.Common.Application.Concept;
using Becoming.Core.Common.Infrastructure.Settings;
using Becoming.Core.TaskManager.Infrastructure.Persistence.Configurations;
using Becoming.Core.TaskManager.Infrastructure.Persistence.Models;

namespace Becoming.Core.TaskManager.Infrastructure.Persistence;

public abstract class TaskManagerContext : DbContext, IUnitOfWork
{
    protected TaskManagerContext(DbContextOptions options) : base(options){ }

    public DbSet<TaskManagerSaveModel> TaskManagers { get; set; } = null!;
    public DbSet<SummaryTaskSaveModel> SummaryTasks { get; set; } = null!;
    public DbSet<SubtaskSaveModel> Subtasks { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema(Scheme.TaskManagerSchemaName);

        builder.ApplyConfiguration(new TaskManagerSaveModelConfiguration());
        builder.ApplyConfiguration(new SummaryTaskSaveModelConfiguration());
        builder.ApplyConfiguration(new SubtaskSaveModelConfiguration());
    }
}