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

    public void Configure(string? name, ApiVersioningOptions options)
    {
        _logger.LogInformation("{Environment.NewLine}", Environment.NewLine);
        _logger.LogInformation(message: "{nameof(ConfigureApiVersioningOptions)} {name} started!",
            nameof(ConfigureApiVersioningOptions), name);

        Configure(options);
    }

    public void Configure(ApiVersioningOptions options)
    {
        options.AssumeDefaultVersionWhenUnspecified = _settings.AssumeDefaultVersionWhenUnspecified;
        options.DefaultApiVersion = new ApiVersion(_settings.DefaultApiVersion.majorVersion, _settings.DefaultApiVersion.minorVersion);
        options.ReportApiVersions = _settings.ReportApiVersions;
        options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());

        _logger.LogInformation("{nameof(ConfigureApiVersioningOptions)} is configured:",
            nameof(ConfigureApiVersioningOptions));
        _logger.LogInformation("Assume Default Version When Unspecified: {options.AssumeDefaultVersionWhenUnspecified}",
            options.AssumeDefaultVersionWhenUnspecified);
        _logger.LogInformation("Default Api Version: {options.DefaultApiVersion}",
            options.DefaultApiVersion);
        _logger.LogInformation("Report Api Versions: {options.ReportApiVersions}",
            options.ReportApiVersions);
        _logger.LogInformation("Api Version Reader: {options.ApiVersionReader}",
            options.ApiVersionReader);
        _logger.LogInformation("{Environment.NewLine}", Environment.NewLine);
    }
}
