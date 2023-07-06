using Becoming.Core.Common.Infrastructure.Settings.ModelOptions;
using Microsoft.Extensions.Options;

namespace HostApp.Configurations.Setup;

sealed class DatabaseOptionsSetup : IConfigureOptions<DatabaseModelOptions>
{
    private readonly IConfiguration _configuration;

    public DatabaseOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(DatabaseModelOptions options)
    {
        _configuration.GetSection(DatabaseModelOptions.SectionName).Bind(options);
    }
}
