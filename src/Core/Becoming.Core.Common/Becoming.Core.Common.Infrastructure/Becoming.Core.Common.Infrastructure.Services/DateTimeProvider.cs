using Becoming.Core.Common.Application.Services;

namespace Becoming.Core.Common.Infrastructure.Services;

public sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}