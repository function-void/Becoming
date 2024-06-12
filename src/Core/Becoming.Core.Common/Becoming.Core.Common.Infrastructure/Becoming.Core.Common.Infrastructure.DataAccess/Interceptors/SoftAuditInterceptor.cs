using Becoming.Core.Common.Application.Services;
using Becoming.Core.Common.Infrastructure.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Becoming.Core.Common.Infrastructure.DataAccess.Interceptors;

public sealed class SoftAuditInterceptor(IDateTimeProvider dateTimeProvider) : SaveChangesInterceptor
{
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        if (eventData.Context is null) return result;

        foreach (var entry in eventData.Context.ChangeTracker.Entries<ISoftAuditable>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = _dateTimeProvider.TimeOffsetUtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedAt = _dateTimeProvider.TimeOffsetUtcNow;
                    break;
                case EntityState.Deleted:
                    entry.Entity.DeletedAt = _dateTimeProvider.TimeOffsetUtcNow;
                    entry.Entity.IsDeleted = true;
                    entry.State = EntityState.Modified;
                    break;
            }
        }

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null) return new(result);

        foreach (var entry in eventData.Context.ChangeTracker.Entries<ISoftAuditable>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = _dateTimeProvider.TimeOffsetUtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedAt = _dateTimeProvider.TimeOffsetUtcNow;
                    break;
                case EntityState.Deleted:
                    entry.Entity.DeletedAt = _dateTimeProvider.TimeOffsetUtcNow;
                    entry.Entity.IsDeleted = true;
                    entry.State = EntityState.Modified;
                    break;
            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
