namespace Becoming.Core.Common.Infrastructure.Settings.ModelOptions;

public class HangfireModelOptions
{
    public const string SectionName = nameof(HangfireModelOptions);

    required public bool UseInMemory { get; set; }
    required public int MaxRetryCount { get; set; }
}
