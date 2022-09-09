namespace HostApp.Configurations.OptionsModel;

public sealed class DatabaseOptions
{
    public const string SectionName = nameof(DatabaseOptions);

    public string ProviderName { get; set; } = null!;
    public int MaxRetryCount { get; set; }
    public int MaxRetryDelay { get; set; }
    public int CommandTimeout { get; set; }
    public bool EnableDetailedErrors { get; set; }
    public bool EnableSensitiveDataLogging { get; set; }
}
