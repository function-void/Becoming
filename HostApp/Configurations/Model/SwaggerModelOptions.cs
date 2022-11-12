namespace HostApp.Configurations.Model;

public sealed class SwaggerModelOptions
{
    public const string SectionName = nameof(SwaggerModelOptions);

    required public string SwaggerTitle { get; set; }
    required public string SchemeReferemceId { get; set; }
    required public string SecuritySchemeName { get; set; }
    required public string BearerFormat { get; set; }
    required public string SchemeDescription { get; set; }
}
