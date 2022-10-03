using System.Text;
using HostApp.Configurations.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace HostApp.Configurations;

sealed class ConfigureJwtBearerOptions : IConfigureNamedOptions<JwtBearerOptions>
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
        _logger.LogInformation($"SaveToken: {options.SaveToken}");
        _logger.LogInformation($"ValidateIssuer: {options.TokenValidationParameters.ValidateIssuer}");
        _logger.LogInformation($"ValidateAudience: {options.TokenValidationParameters.ValidateAudience}");
        _logger.LogInformation($"ValidateLifetime: {options.TokenValidationParameters.ValidateLifetime}");
        _logger.LogInformation($"ValidateIssuerSigningKey: {options.TokenValidationParameters.ValidateIssuerSigningKey}");
        _logger.LogInformation($"ValidIssuer: {options.TokenValidationParameters.ValidIssuer}");
        _logger.LogInformation($"ValidAudience: {options.TokenValidationParameters.ValidAudience}");
        _logger.LogInformation($"SecretKey: {_settings.SecretKey}");
        _logger.LogInformation(Environment.NewLine);
    }
}
