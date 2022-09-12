using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Options;

namespace HostApp.Configurations;

public class ConfigureApiVersioningOptions : IConfigureNamedOptions<ApiVersioningOptions>
{
    private readonly ILogger<ConfigureApiVersioningOptions> _logger;

    public ConfigureApiVersioningOptions(ILogger<ConfigureApiVersioningOptions> logger)
    {
        _logger = logger;
    }

    public void Configure(string name, ApiVersioningOptions options)
    {
        _logger.LogInformation(Environment.NewLine);
        _logger.LogInformation(message: $"{nameof(ConfigureApiVersioningOptions)} {name} started!");
        Configure(options);
    }

    public void Configure(ApiVersioningOptions options)
    {
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.ReportApiVersions = true;
        options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());

        _logger.LogInformation($"{nameof(ConfigureApiVersioningOptions)} is configured:");
        _logger.LogInformation($"AssumeDefaultVersionWhenUnspecified: {true}");
        _logger.LogInformation($"DefaultApiVersion: {""}");
        _logger.LogInformation($"ReportApiVersions: {true}");
        _logger.LogInformation($"ApiVersionReader: {""}");
        _logger.LogInformation(Environment.NewLine);
    }
}
