using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Options;

namespace HostApp.Configurations;

public class ConfigureCorsOptions : IConfigureNamedOptions<CorsOptions>
{
    private readonly ILogger<ConfigureCorsOptions> _logger;

    public ConfigureCorsOptions(ILogger<ConfigureCorsOptions> logger)
    {
        _logger = logger;
    }

    public void Configure(string name, CorsOptions options)
    {
        _logger.LogInformation(message: $"\n{nameof(ConfigureCorsOptions)} {name} started!");
        Configure(options);
    }

    public void Configure(CorsOptions options)
    {
        options.AddPolicy("CORS_Policy", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

        _logger.LogInformation($"{nameof(ConfigureCorsOptions)} is configured:");

        _logger.LogInformation(Environment.NewLine);
    }
}
