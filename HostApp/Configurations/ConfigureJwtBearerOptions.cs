using System.Text;
using HostApp.Configurations.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace HostApp.Configurations;

public sealed class ConfigureJwtBearerOptions : IConfigureNamedOptions<JwtBearerOptions>
{
    private readonly ILogger<ConfigureJwtBearerOptions> _logger;
    private readonly JwtModelOptions _settings;

    public ConfigureJwtBearerOptions(ILogger<ConfigureJwtBearerOptions> logger, JwtModelOptions settings)
    {
        _logger = logger;
        _settings = settings;
    }

    public void Configure(string name, JwtBearerOptions options)
    {
        _logger.LogInformation(Environment.NewLine);
        _logger.LogInformation(message: $"{nameof(ConfigureJwtBearerOptions)} {name} started!");
        Configure(options);
    }

    public void Configure(JwtBearerOptions options)
    {
        options.SaveToken = _settings.SaveToken;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = _settings.ValidateIssuer,
            ValidateAudience = _settings.ValidateAudience,
            ValidateLifetime = _settings.ValidateLifetime,
            ValidateIssuerSigningKey = _settings.ValidateIssuerSigningKey,
            ValidIssuer = _settings.Issuer,
            ValidAudience = _settings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey))
        };

        _logger.LogInformation($"{nameof(ConfigureJwtBearerOptions)} is configured:");
        _logger.LogInformation($"SaveToken: {_settings.SaveToken}");
        _logger.LogInformation($"ValidateIssuer: {_settings.ValidateIssuer}");
        _logger.LogInformation($"ValidateAudience: {_settings.ValidateAudience}");
        _logger.LogInformation($"ValidateLifetime: {_settings.ValidateLifetime}");
        _logger.LogInformation($"ValidateIssuerSigningKey: {_settings.ValidateIssuerSigningKey}");
        _logger.LogInformation($"ValidIssuer: {_settings.Issuer}");
        _logger.LogInformation($"ValidAudience: {_settings.Audience}");
        _logger.LogInformation($"SecretKey: {_settings.SecretKey}");
        _logger.LogInformation(Environment.NewLine);
    }
}
