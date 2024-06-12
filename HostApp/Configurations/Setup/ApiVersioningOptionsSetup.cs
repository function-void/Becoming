using HostApp.Configurations.Model;
using Microsoft.Extensions.Options;

namespace HostApp.Configurations.Setup;

sealed class ApiVersioningOptionsSetup : IConfigureOptions<ApiVersioningModelOptions>
{
    private readonly IConfiguration _configuration;

    public ApiVersioningOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(ApiVersioningModelOptions options)
    {
        var config = _configuration
            .GetRequiredSection($"{ApiVersioningModelOptions.SectionName}:{ApiVersioningModelOptions.ApiVersionSectionName}");

        options.DefaultApiVersion = new()
        {
            majorVersion = int.Parse(config.GetSection(ApiVersioningModelOptions.MajorVersionSectionName)!.Value!),
            minorVersion = int.Parse(config.GetSection(ApiVersioningModelOptions.MinorVersionSectionName)!.Value!)
        };

        _configuration.GetSection(ApiVersioningModelOptions.SectionName).Bind(options);
    }
}