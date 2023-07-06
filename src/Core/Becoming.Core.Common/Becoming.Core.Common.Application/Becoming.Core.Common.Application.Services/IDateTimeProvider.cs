namespace Becoming.Core.Common.Application.Services;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
    DateTimeOffset TimeOffsetUtcNow { get; }

    DateTime Now { get; }
    DateTimeOffset TimeOffsetNow { get; }
}