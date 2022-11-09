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

    public void Configure(string? name, ApiExplorerOptions options)
    {
        _logger.LogInformation("{Environment.NewLine}", Environment.NewLine);
        _logger.LogInformation(message: "{nameof(ConfigureApiExplorerOptions)} {name} started!",
            nameof(ConfigureSwaggerOptions), name);

        Configure(options);
    }

    public void Configure(ApiExplorerOptions options)
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;

        _logger.LogInformation("{nameof(ConfigureApiExplorerOptions)} is configured:",
            nameof(ConfigureApiExplorerOptions));
        _logger.LogInformation("Group Name Format: {options.GroupNameFormat}",
            options.GroupNameFormat);
        _logger.LogInformation("Substitute Api Version In Url: {options.SubstituteApiVersionInUrl}",
            options.SubstituteApiVersionInUrl);
        _logger.LogInformation("{Environment.NewLine}", Environment.NewLine);
    }
}
