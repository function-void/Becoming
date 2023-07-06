using Microsoft.EntityFrameworkCore;

namespace Becoming.Core.Common.Infrastructure.Hangfire.Persistence;

public class EventStoreContext : DbContext
{
    public EventStoreContext(DbContextOptions<EventStoreContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {

    }
}
