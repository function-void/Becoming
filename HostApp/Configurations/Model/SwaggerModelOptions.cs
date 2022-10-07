namespace HostApp.Configurations.Model;

public sealed class SwaggerModelOptions
{
    public const string SectionName = nameof(SwaggerModelOptions);

    public string SwaggerTitle { get; set; } = null!;
    public string SchemeReferemceId { get; set; } = null!;
    public string SecuritySchemeName { get; set; } = null!;
    public string BearerFormat { get; set; } = null!;
    public string SchemeDescription { get; set; } = null!;
}
