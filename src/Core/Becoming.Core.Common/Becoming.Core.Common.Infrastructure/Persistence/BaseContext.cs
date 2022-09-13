
using Becoming.Core.Common.Abstractions.Contracts;
using Becoming.Core.Common.Infrastructure.Services.Services;
using Becoming.Core.Common.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace Becoming.Core.Common.Infrastructure.Persistence;

public abstract class BaseContext : DbContext
{
    private readonly IDateTimeProvider _dateTimeProvider;

    protected BaseContext(DbContextOptions options) : base(options)
    {
        _dateTimeProvider = new DateTimeProvider();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableModel>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = _dateTimeProvider.UtcNow;
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedAt = _dateTimeProvider.UtcNow;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
