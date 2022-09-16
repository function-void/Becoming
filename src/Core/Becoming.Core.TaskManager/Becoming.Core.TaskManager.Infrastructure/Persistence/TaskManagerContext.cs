using Becoming.Core.Common.Infrastructure.Persistence;
using Becoming.Core.Common.Infrastructure.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Becoming.Core.TaskManager.Infrastructure.Persistence;

public abstract class TaskManagerContext : BaseContext
{
    protected TaskManagerContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema(DbConstants.TaskManagerSchemaName);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}