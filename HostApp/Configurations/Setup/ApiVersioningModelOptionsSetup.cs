using HostApp.Configurations.Model;
using Microsoft.Extensions.Options;

namespace HostApp.Configurations.Setup;

public sealed class ApiVersioningModelOptionsSetup : IConfigureOptions<ApiVersioningModelOptions>
{
    private readonly IConfiguration _configuration;

    public ApiVersioningModelOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(ApiVersioningModelOptions options)
    {
        _configuration.GetSection(ApiVersioningModelOptions.SectionName).Bind(options);
    }
}

