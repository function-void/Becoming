using Microsoft.EntityFrameworkCore;

namespace Becoming.Core.Common.Infrastructure.Hangfire.Persistence;

public class HangfireDbContext : DbContext
{
    public HangfireDbContext(DbContextOptions<HangfireDbContext> options) : base(options) { }
}
