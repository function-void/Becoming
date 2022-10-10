using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Becoming.Core.TaskManager.Infrastructure.SqlServer;

public sealed class TaskManagerSqlServerContextFactory : IDesignTimeDbContextFactory<TaskManagerSqlServerContext>
{
    public TaskManagerSqlServerContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<TaskManagerSqlServerContext>()
            .UseSqlServer(args[0])
            .Options;

        return new TaskManagerSqlServerContext(options);
    }
}
