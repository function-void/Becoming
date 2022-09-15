namespace HostApp.Configurations.Model;

public sealed class ApiVersioningModelOptions
{
    public const string SectionName = nameof(ApiVersioningModelOptions);
    public const string ApiVersionSectionName = "ApiActualVersion";
    public const string MajorVersionSectionName = "majorVersion";
    public const string MinorVersionSectionName = "minorVersion";

    public bool AssumeDefaultVersionWhenUnspecified { get; set; }
    public (int majorVersion, int minorVersion) DefaultApiVersion { get; set; }
    public bool ReportApiVersions { get; set; }
    public string ApiVersionReader { get; set; } = null!;
}
