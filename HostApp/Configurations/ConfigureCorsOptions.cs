using HostApp.Configurations.Model;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Options;

namespace HostApp.Configurations;

sealed class ConfigureCorsOptions : IConfigureNamedOptions<CorsOptions>
{
    private readonly ILogger<ConfigureCorsOptions> _logger;
    private readonly CorsModelOptions _settings;

    public ConfigureCorsOptions(ILogger<ConfigureCorsOptions> logger, CorsModelOptions settings)
    {
        _logger = logger;
        _settings = settings;
    }

    public void Configure(string? name, CorsOptions options)
    {
        _logger.LogInformation("{Environment.NewLine}", Environment.NewLine);
        _logger.LogInformation(message: "{nameof(ConfigureCorsOptions)} {name} started!",
            nameof(ConfigureCorsOptions), name);

        Configure(options);
    }

    public void Configure(CorsOptions options)
    {
        options.AddPolicy(_settings.Policy, builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

        _logger.LogInformation("{nameof(ConfigureCorsOptions)} is configured:",
            nameof(ConfigureCorsOptions));
        _logger.LogInformation("Policy Name: {_settings.Policy}",
           _settings.Policy);
        _logger.LogInformation("{Environment.NewLine}", Environment.NewLine);
    }
}
