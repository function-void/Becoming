using Microsoft.Extensions.Options;
using StackExchange.Profiling;

namespace HostApp.Configurations;

sealed class ConfigureMiniProfilerOptions : IConfigureNamedOptions<MiniProfilerOptions>
{
    private readonly ILogger<ConfigureMiniProfilerOptions> _logger;

    public ConfigureMiniProfilerOptions(ILogger<ConfigureMiniProfilerOptions> logger)
    {
        _logger = logger;
    }

    public void Configure(string name, MiniProfilerOptions options)
    {
        _logger.LogInformation(Environment.NewLine);
        _logger.LogInformation(message: $"{nameof(MiniProfilerOptions)} {name} started!");
        Configure(options);
    }

    public void Configure(MiniProfilerOptions options)
    {
        options.RouteBasePath = "/profiler";

        _logger.LogInformation($"{nameof(MiniProfilerOptions)} is configured:");
        _logger.LogInformation($"RouteBasePath: {options.RouteBasePath}");
        _logger.LogInformation(Environment.NewLine);
    }
}
