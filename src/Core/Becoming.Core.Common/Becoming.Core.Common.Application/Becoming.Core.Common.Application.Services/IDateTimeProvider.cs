namespace Becoming.Core.Common.Application.Services;

public interface IDateTimeProvider
{
    DateTime Now { get; }
    DateTime UtcNow { get; }
    DateTimeOffset TimeOffsetNow { get; }
    DateTimeOffset TimeOffsetUtcNow { get; }
    DateOnly DateOnly { get; }
    TimeOnly TimeOnly { get; }
}