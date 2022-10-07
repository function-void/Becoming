using Becoming.Core.Common.Infrastructure.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Options;

namespace HostApp.Configurations;

sealed class ConfigureMvcOptions : IConfigureNamedOptions<MvcOptions>
{
    private readonly ILogger<ConfigureMvcOptions> _logger;

    public ConfigureMvcOptions(ILogger<ConfigureMvcOptions> logger)
    {
        _logger = logger;
    }

    public void Configure(string name, MvcOptions options)
    {
        _logger.LogInformation("{Environment.NewLine}", Environment.NewLine);
        _logger.LogInformation(message: "{nameof(ConfigureMvcOptions)} {name} started!",
            nameof(ConfigureMvcOptions), name);

        Configure(options);
    }

    public void Configure(MvcOptions options)
    {
        options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));

        _logger.LogInformation("{nameof(ConfigureMvcOptions)} is configured:",
            nameof(ConfigureMvcOptions));
        _logger.LogInformation("Route Token Transformer Convention: {nameof(SlugifyParameterTransformer)}",
            nameof(SlugifyParameterTransformer));
        _logger.LogInformation("{Environment.NewLine}", Environment.NewLine);
    }
}
