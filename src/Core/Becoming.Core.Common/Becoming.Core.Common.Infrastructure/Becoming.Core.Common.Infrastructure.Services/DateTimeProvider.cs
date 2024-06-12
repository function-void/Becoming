using Becoming.Core.Common.Application.Services;

namespace Becoming.Core.Common.Infrastructure.Services;

public sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;

    public DateTime Now => DateTime.Now;

    public DateTimeOffset TimeOffsetUtcNow => DateTimeOffset.UtcNow;

    public DateTimeOffset TimeOffsetNow => DateTimeOffset.Now;

    public DateOnly DateOnly => throw new NotImplementedException();

    public TimeOnly TimeOnly => throw new NotImplementedException();

    public TimeSpan TimeSpanUtcNow => TimeSpan.Zero;
}