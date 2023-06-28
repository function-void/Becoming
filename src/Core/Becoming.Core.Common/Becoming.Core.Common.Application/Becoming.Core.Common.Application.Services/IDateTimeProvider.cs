namespace Becoming.Core.Common.Application.Services;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}