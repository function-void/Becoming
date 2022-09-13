using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace HostApp.Configurations;

public sealed class ConfigureAuthenticationOptions : IConfigureNamedOptions<AuthenticationOptions>
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
        _logger.LogInformation($"DefaultAuthenticateScheme: {JwtBearerDefaults.AuthenticationScheme}");
        _logger.LogInformation($"DefaultChallengeScheme: {JwtBearerDefaults.AuthenticationScheme}");
        _logger.LogInformation($"DefaultScheme: {JwtBearerDefaults.AuthenticationScheme}");
        _logger.LogInformation(Environment.NewLine);
    }
}
