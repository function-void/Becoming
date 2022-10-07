using HostApp.Configurations.Model;
using Microsoft.Extensions.Options;

namespace HostApp.Configurations.Setup;

sealed class CorsOptionsSetup : IConfigureOptions<CorsModelOptions>
{
    private readonly IConfiguration _configuration;

    public CorsOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(CorsModelOptions options)
    {
        _configuration.GetSection(CorsModelOptions.SectionName).Bind(options);
    }
}
