namespace HostApp.Configurations.Model;

public class HangfireModelOptions
{
    public const string SectionName = nameof(HangfireModelOptions);

    public bool UseInMemory { get; set; }
    public int MaxRetryCount { get; set; }
    public int MaxRetryDelay { get; set; }
    public int CommandTimeout { get; set; }
    public bool EnableDetailedErrors { get; set; }
    public bool EnableSensitiveDataLogging { get; set; }
}
