namespace Becoming.Core.Common.Infrastructure.Settings.ModelOptions;

public sealed class DatabaseModelOptions
{
    public const string SectionName = nameof(DatabaseModelOptions);
    required public bool MultipleQueriesWithinOneTransaction { get; set; }
    required public int MaxRetryCount { get; set; }
    required public int MaxRetryDelay { get; set; }
    required public int CommandTimeout { get; set; }
    required public bool EnableDetailedErrors { get; set; }
    required public bool EnableSensitiveDataLogging { get; set; }
}
