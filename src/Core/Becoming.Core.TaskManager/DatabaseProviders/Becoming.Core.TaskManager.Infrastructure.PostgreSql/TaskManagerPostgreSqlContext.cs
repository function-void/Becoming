using Becoming.Core.Common.Abstractions.Contracts;
using Becoming.Core.TaskManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Becoming.Core.TaskManager.Infrastructure.PostgreSql;

public sealed class TaskManagerPostgreSqlContext : TaskManagerContext
{
    public TaskManagerPostgreSqlContext(DbContextOptions<TaskManagerPostgreSqlContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}