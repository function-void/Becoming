namespace HostApp.Configurations.Model;

// TODO: relocate on infrastructure layer
public sealed class DatabaseModelOptions
{
    public const string SectionName = nameof(DatabaseModelOptions);

    public string ProviderName { get; set; } = null!;
    public int MaxRetryCount { get; set; }
    public int MaxRetryDelay { get; set; }
    public int CommandTimeout { get; set; }
    public bool EnableDetailedErrors { get; set; }
    public bool EnableSensitiveDataLogging { get; set; }
}
