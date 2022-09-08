using Becoming.Core.Common.Abstractions.Contracts;

namespace Becoming.Core.Common.Infrastructure.Services.Services;

public sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}