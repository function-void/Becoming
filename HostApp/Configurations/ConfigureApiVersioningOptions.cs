using HostApp.Configurations.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Options;

namespace HostApp.Configurations;

sealed class ConfigureApiVersioningOptions : IConfigureNamedOptions<ApiVersioningOptions>
{
    private readonly ILogger<ConfigureApiVersioningOptions> _logger;
    private readonly ApiVersioningModelOptions _settings;

    public ConfigureApiVersioningOptions(ILogger<ConfigureApiVersioningOptions> logger, ApiVersioningModelOptions settings)
    {
        _logger = logger;
        _settings = settings;
    }

    public void Configure(string name, ApiVersioningOptions options)
    {
        _logger.LogInformation(Environment.NewLine);
        _logger.LogInformation(message: $"{nameof(ConfigureApiVersioningOptions)} {name} started!");
        Configure(options);
    }

    public void Configure(ApiVersioningOptions options)
    {
        options.AssumeDefaultVersionWhenUnspecified = _settings.AssumeDefaultVersionWhenUnspecified;
        options.DefaultApiVersion = new ApiVersion(_settings.DefaultApiVersion.majorVersion, _settings.DefaultApiVersion.minorVersion);
        options.ReportApiVersions = _settings.ReportApiVersions;
        options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());

        _logger.LogInformation($"{nameof(ConfigureApiVersioningOptions)} is configured:");
        _logger.LogInformation($"AssumeDefaultVersionWhenUnspecified: {options.AssumeDefaultVersionWhenUnspecified}");
        _logger.LogInformation($"DefaultApiVersion: {options.DefaultApiVersion}");
        _logger.LogInformation($"ReportApiVersions: {options.ReportApiVersions}");
        _logger.LogInformation($"ApiVersionReader: {options.ApiVersionReader}");
        _logger.LogInformation(Environment.NewLine);
    }
}
