namespace HostApp.Configurations.Model;

public sealed class ApiVersioningModelOptions
{
    public const string SectionName = nameof(ApiVersioningModelOptions);
    public const string ApiVersionSectionName = "ApiActualVersion";
    public const string MajorVersionSectionName = "majorVersion";
    public const string MinorVersionSectionName = "minorVersion";

    required public bool AssumeDefaultVersionWhenUnspecified { get; set; }
    required public(int majorVersion, int minorVersion) DefaultApiVersion { get; set; }
    required public bool ReportApiVersions { get; set; }
    required public string ApiVersionReader { get; set; }
}
