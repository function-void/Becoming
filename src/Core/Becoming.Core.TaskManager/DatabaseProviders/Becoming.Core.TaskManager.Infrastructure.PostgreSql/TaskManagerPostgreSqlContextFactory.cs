using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Becoming.Core.TaskManager.Infrastructure.PostgreSql;

public sealed class TaskManagerPostgreSqlContextFactory : IDesignTimeDbContextFactory<TaskManagerPostgreSqlContext>
{
    public TaskManagerPostgreSqlContext CreateDbContext(string[] args)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        var options = new DbContextOptionsBuilder<TaskManagerPostgreSqlContext>()
            .UseNpgsql(args[0])
            .Options;

        return new TaskManagerPostgreSqlContext(options);
    }
}
