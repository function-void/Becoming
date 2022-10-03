using HostApp.Configurations.Model;
using Microsoft.Extensions.Options;

namespace HostApp.Configurations.Setup;

sealed class JwtOptionsSetup : IConfigureOptions<JwtModelOptions>
{
    private readonly IConfiguration _configuration;

    public JwtOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtModelOptions options)
    {
        _configuration.GetSection(JwtModelOptions.SectionName).Bind(options);
    }
}
