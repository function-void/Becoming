using Becoming.Core.Common.Infrastructure.Settings;
using Microsoft.Extensions.Options;

namespace HostApp.Configurations.Setup;

sealed class HangfireOptionsSetup : IConfigureOptions<HangfireModelOptions>
{
    private readonly IConfiguration _configuration;

    public HangfireOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(HangfireModelOptions options)
    {
        _configuration.GetSection(HangfireModelOptions.SectionName).Bind(options);
    }
}
