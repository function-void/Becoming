namespace HostApp.Configurations.Model;

public sealed class CorsModelOptions
{
    public const string SectionName = nameof(CorsModelOptions);

    required public string Policy { get; set; } = null!;
}
