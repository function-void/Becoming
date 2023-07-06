using Becoming.Core.Common.Application.Services;

namespace Becoming.Core.Common.Infrastructure.Services;

public sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;

    public DateTime Now => DateTime.Now;

    public DateTimeOffset TimeOffsetUtcNow => DateTimeOffset.UtcNow;

    public DateTimeOffset TimeOffsetNow => DateTimeOffset.Now;
}