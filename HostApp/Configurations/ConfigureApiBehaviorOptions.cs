using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HostApp.Configurations;

sealed class ConfigureApiBehaviorOptions : IConfigureNamedOptions<ApiBehaviorOptions>
{
    private readonly ILogger<ConfigureApiBehaviorOptions> _logger;

    public ConfigureApiBehaviorOptions(ILogger<ConfigureApiBehaviorOptions> logger)
    {
        _logger = logger;
    }

    public void Configure(string? name, ApiBehaviorOptions options)
    {
        _logger.LogInformation("{Environment.NewLine}", Environment.NewLine);
        _logger.LogInformation(message: "{nameof(ConfigureSwaggerOptions)} {name} started!",
            nameof(ConfigureSwaggerOptions), name);

        Configure(options);
    }

    public void Configure(ApiBehaviorOptions options)
    {
        options.SuppressModelStateInvalidFilter = true;

        _logger.LogInformation("{nameof(ConfigureJwtBearerOptions)} is configured:",
            nameof(ConfigureJwtBearerOptions));
        _logger.LogInformation("Suppress Model State Invalid Filter: {options.SuppressModelStateInvalidFilter}",
            options.SuppressModelStateInvalidFilter);
        _logger.LogInformation("{Environment.NewLine}", Environment.NewLine);
    }
}
