using HostApp.Configurations.Model;
using Microsoft.Extensions.Options;

namespace HostApp.Configurations.Setup;

public class JwtModelOptionsSetup : IConfigureOptions<JwtModelOptions>
{
    private readonly IConfiguration _configuration;

    public JwtModelOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtModelOptions options)
    {
        _configuration.GetSection(JwtModelOptions.SectionName).Bind(options);
    }
}
