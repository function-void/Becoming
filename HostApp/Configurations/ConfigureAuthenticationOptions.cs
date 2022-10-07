using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace HostApp.Configurations;

sealed class ConfigureAuthenticationOptions : IConfigureNamedOptions<AuthenticationOptions>
{
    private readonly ILogger<ConfigureAuthenticationOptions> _logger;

    public ConfigureAuthenticationOptions(ILogger<ConfigureAuthenticationOptions> logger)
    {
        _logger = logger;
    }

    public void Configure(string name, AuthenticationOptions options)
    {
        _logger.LogInformation("{Environment.NewLine}", Environment.NewLine);
        _logger.LogInformation(message: "{nameof(ConfigureAuthenticationOptions)} {name} started!",
            nameof(ConfigureAuthenticationOptions), name);

        Configure(options);
    }

    public void Configure(AuthenticationOptions options)
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

        _logger.LogInformation("{nameof(ConfigureAuthenticationOptions)} is configured:",
            nameof(ConfigureAuthenticationOptions));
        _logger.LogInformation("Default Authenticate Scheme: {options.DefaultAuthenticateScheme}",
            options.DefaultAuthenticateScheme);
        _logger.LogInformation("Default Challenge Scheme: {options.DefaultAuthenticateScheme}",
            options.DefaultAuthenticateScheme);
        _logger.LogInformation("Default Scheme: {options.DefaultAuthenticateScheme}",
            options.DefaultAuthenticateScheme);
        _logger.LogInformation("{Environment.NewLine}", Environment.NewLine);
    }
}
