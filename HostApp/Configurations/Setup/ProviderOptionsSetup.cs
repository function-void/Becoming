﻿using Becoming.Core.Common.Infrastructure.Settings;
using Microsoft.Extensions.Options;

namespace HostApp.Configurations.Setup;

sealed class ProviderOptionsSetup : IConfigureOptions<ProviderModelOptions>
{
    private readonly IConfiguration _configuration;

    public ProviderOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(ProviderModelOptions options)
    {
        string value = _configuration[ProviderModelOptions.SectionName];
        options.Name = value;

        _configuration.GetSection(ProviderModelOptions.SectionName).Bind(options);
    }
}
