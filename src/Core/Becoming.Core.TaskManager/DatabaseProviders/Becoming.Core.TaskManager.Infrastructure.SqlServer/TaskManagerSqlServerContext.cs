using Becoming.Core.TaskManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Becoming.Core.TaskManager.Infrastructure.SqlServer;

public sealed class TaskManagerSqlServerContext : TaskManagerContext
{
    public TaskManagerSqlServerContext(DbContextOptions<TaskManagerSqlServerContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}