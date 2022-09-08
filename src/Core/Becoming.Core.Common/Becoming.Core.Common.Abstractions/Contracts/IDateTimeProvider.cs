namespace Becoming.Core.Common.Abstractions.Contracts;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}