using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;

namespace HostApp.Configurations;

sealed class ConfigureApiExplorerOptions : IConfigureNamedOptions<ApiExplorerOptions>
{
    private readonly ILogger<ConfigureApiExplorerOptions> _logger;

    public ConfigureApiExplorerOptions(ILogger<ConfigureApiExplorerOptions> logger)
    {
        _logger = logger;
    }

    public void Configure(string name, ApiExplorerOptions options)
    {
        _logger.LogInformation(Environment.NewLine);
        _logger.LogInformation(message: $"{nameof(ConfigureApiExplorerOptions)} {name} started!");
        Configure(options);
    }

    public void Configure(ApiExplorerOptions options)
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;

        _logger.LogInformation($"{nameof(ConfigureApiExplorerOptions)} is configured:");
        _logger.LogInformation($"GroupNameFormat: {"'v'VVV"}");
        _logger.LogInformation($"SubstituteApiVersionInUrl: {true}");
        _logger.LogInformation(Environment.NewLine);
    }
}
