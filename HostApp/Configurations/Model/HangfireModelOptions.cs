namespace HostApp.Configurations.Model;

public class HangfireModelOptions
{
    public const string SectionName = nameof(HangfireModelOptions);

    public string ProviderName { get; set; } = null!;
    public bool UseInMemory { get; set; }
    public int MaxRetryCount { get; set; }
}
