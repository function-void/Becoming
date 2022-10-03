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
        _logger.LogInformation(Environment.NewLine);
        _logger.LogInformation(message: $"{nameof(ConfigureAuthenticationOptions)} {name} started!");
        Configure(options);
    }

    public void Configure(AuthenticationOptions options)
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

        _logger.LogInformation($"{nameof(ConfigureAuthenticationOptions)} is configured:");
        _logger.LogInformation($"DefaultAuthenticateScheme: {options.DefaultAuthenticateScheme}");
        _logger.LogInformation($"DefaultChallengeScheme: {options.DefaultAuthenticateScheme}");
        _logger.LogInformation($"DefaultScheme: {options.DefaultAuthenticateScheme}");
        _logger.LogInformation(Environment.NewLine);
    }
}
