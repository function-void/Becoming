namespace HostApp.Configurations.Model;

public sealed class ApiVersioningModelOptions
{
    public const string SectionName = nameof(ApiVersioningModelOptions);

    public bool AssumeDefaultVersionWhenUnspecified { get; set; }
    public (string, string) DefaultApiVersion { get; set; }
    public bool ReportApiVersions { get; set; }
    public string ApiVersionReader { get; set; } = null!;
}
