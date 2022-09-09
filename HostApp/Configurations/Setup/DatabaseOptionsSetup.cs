using HostApp.Configurations.OptionsModel;
using Microsoft.Extensions.Options;

namespace HostApp.Configurations.Setup;

public class DatabaseOptionsSetup : IConfigureOptions<DatabaseOptions>
{
    private readonly IConfiguration _configuration;

    public DatabaseOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(DatabaseOptions options)
    {
        _configuration.GetSection(DatabaseOptions.SectionName).Bind(options);
    }
}
