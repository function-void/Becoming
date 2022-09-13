using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Options;

namespace HostApp.Configurations;

public sealed class ConfigureForwardedHeadersOptions : IConfigureNamedOptions<ForwardedHeadersOptions>
{
    private readonly ILogger<ConfigureForwardedHeadersOptions> _logger;

    public ConfigureForwardedHeadersOptions(ILogger<ConfigureForwardedHeadersOptions> logger)
    {
        _logger = logger;
    }

    public void Configure(string name, ForwardedHeadersOptions options)
    {
        _logger.LogInformation(Environment.NewLine);
        _logger.LogInformation(message: $"{nameof(ConfigureForwardedHeadersOptions)} {name} started!");
        Configure(options);
    }

    public void Configure(ForwardedHeadersOptions options)
    {
        options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;

        _logger.LogInformation($"{nameof(ForwardedHeadersOptions)} is configured:");
        _logger.LogInformation($"ForwardedHeaders: {ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto}");
        _logger.LogInformation(Environment.NewLine);
    }
}
