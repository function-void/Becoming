using Microsoft.EntityFrameworkCore;
using Becoming.Core.TaskManager.Infrastructure.Persistence;

namespace Becoming.Core.TaskManager.Infrastructure.PostgreSql;

public sealed class TaskManagerPostgreSqlContext : TaskManagerContext
{
    public TaskManagerPostgreSqlContext(DbContextOptions<TaskManagerPostgreSqlContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}