using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Options;

namespace HostApp.Configurations;

sealed class ConfigureForwardedHeadersOptions : IConfigureNamedOptions<ForwardedHeadersOptions>
{
    private readonly ILogger<ConfigureForwardedHeadersOptions> _logger;

    public ConfigureForwardedHeadersOptions(ILogger<ConfigureForwardedHeadersOptions> logger)
    {
        _logger = logger;
    }

    public void Configure(string name, ForwardedHeadersOptions options)
    {
        _logger.LogInformation("{Environment.NewLine}", Environment.NewLine);
        _logger.LogInformation(message: "{nameof(ConfigureForwardedHeadersOptions)} {name} started!",
            nameof(ConfigureForwardedHeadersOptions), name);

        Configure(options);
    }

    public void Configure(ForwardedHeadersOptions options)
    {
        options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;

        _logger.LogInformation("{nameof(ForwardedHeadersOptions)} is configured:",
            nameof(ForwardedHeadersOptions));
        _logger.LogInformation("Forwarded Headers: {options.ForwardedHeaders}",
            options.ForwardedHeaders);
        _logger.LogInformation("{Environment.NewLine}", Environment.NewLine);
    }
}
