﻿using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.Options;

namespace HostApp.Configurations;

sealed class ConfigureJsonOptions : IConfigureNamedOptions<JsonOptions>
{
    private readonly ILogger<ConfigureJsonOptions> _logger;

    public ConfigureJsonOptions(ILogger<ConfigureJsonOptions> logger)
    {
        _logger = logger;
    }

    public void Configure(string name, JsonOptions options)
    {
        _logger.LogInformation(Environment.NewLine);
        _logger.LogInformation(message: $"{nameof(ConfigureJsonOptions)} {name} started!");
        Configure(options);
    }

    public void Configure(JsonOptions options)
    {
        options.SerializerOptions.IncludeFields = true;

        _logger.LogInformation($"{nameof(ConfigureJsonOptions)} is configured:");
        _logger.LogInformation($"IncludeFields: {options.SerializerOptions.IncludeFields}");
        _logger.LogInformation(Environment.NewLine);
    }
}
