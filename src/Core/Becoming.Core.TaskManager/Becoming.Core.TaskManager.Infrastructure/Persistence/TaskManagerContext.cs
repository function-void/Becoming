using Becoming.Core.TaskManager.Infrastructure.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Becoming.Core.TaskManager.Infrastructure.Persistence;

public class TaskManagerContext : DbContext
{
    public TaskManagerContext(DbContextOptions<TaskManagerContext> options)
          : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema(DbConstants.SchemaName);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
