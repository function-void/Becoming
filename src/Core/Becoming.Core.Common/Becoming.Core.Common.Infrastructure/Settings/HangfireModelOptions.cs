namespace Becoming.Core.Common.Infrastructure.Settings;

public class HangfireModelOptions
{
    public const string SectionName = nameof(HangfireModelOptions);

    public bool UseInMemory { get; set; }
    public int MaxRetryCount { get; set; }
}