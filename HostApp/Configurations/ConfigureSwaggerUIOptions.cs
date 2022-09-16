﻿using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace HostApp.Configurations;

public class ConfigureSwaggerUIOptions : IConfigureNamedOptions<SwaggerUIOptions>
{
    private readonly ILogger<ConfigureSwaggerUIOptions> _logger;
    private readonly IApiVersionDescriptionProvider _provider;

    public ConfigureSwaggerUIOptions(ILogger<ConfigureSwaggerUIOptions> logger, IApiVersionDescriptionProvider provider)
    {
        _logger = logger;
        _provider = provider;
    }

    public void Configure(string name, SwaggerUIOptions options)
    {
        _logger.LogInformation(Environment.NewLine);
        _logger.LogInformation(message: $"{nameof(ConfigureSwaggerUIOptions)} {name} started!");
        Configure(options);
    }

    public void Configure(SwaggerUIOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName);

        _logger.LogInformation($"{nameof(ConfigureSwaggerUIOptions)} is configured!");
    }
}