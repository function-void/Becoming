using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HostApp.Configurations;

public class ConfigureApiBehaviorOptions : IConfigureNamedOptions<ApiBehaviorOptions>
{
    private readonly ILogger<ConfigureApiBehaviorOptions> _logger;

    public ConfigureApiBehaviorOptions(ILogger<ConfigureApiBehaviorOptions> logger)
    {
        _logger = logger;
    }

    public void Configure(string name, ApiBehaviorOptions options)
    {
        _logger.LogInformation(message: $"\n{nameof(ConfigureSwaggerOptions)} {name} started!");
        Configure(options);
    }

    public void Configure(ApiBehaviorOptions options)
    {
        options.SuppressModelStateInvalidFilter = true;

        _logger.LogInformation($"{nameof(ConfigureJwtBearerOptions)} is configured:");
        _logger.LogInformation($"SuppressModelStateInvalidFilter: {true}");

        _logger.LogInformation(Environment.NewLine);
    }
}
