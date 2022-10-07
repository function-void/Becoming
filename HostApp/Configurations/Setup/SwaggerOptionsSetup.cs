using HostApp.Configurations.Model;
using Microsoft.Extensions.Options;

namespace HostApp.Configurations.Setup;

sealed class SwaggerOptionsSetup : IConfigureOptions<SwaggerModelOptions>
{
    private readonly IConfiguration _configuration;

    public SwaggerOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(SwaggerModelOptions options)
    {
        _configuration.GetSection(SwaggerModelOptions.SectionName).Bind(options);
    }
}
