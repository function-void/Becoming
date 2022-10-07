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
        _logger.LogInformation("{Environment.NewLine}", Environment.NewLine);
        _logger.LogInformation(message: "{nameof(ConfigureJwtBearerOptions)} {name} started!",
            nameof(ConfigureJwtBearerOptions), name);
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

        _logger.LogInformation("{nameof(ConfigureJwtBearerOptions)} is configured:",
            nameof(ConfigureJwtBearerOptions));
        _logger.LogInformation("Save Token: {options.SaveToken}",
            options.SaveToken);
        _logger.LogInformation("Validate Issuer: {options.TokenValidationParameters.ValidateIssuer}"
            , options.TokenValidationParameters.ValidateIssuer);
        _logger.LogInformation("Validate Audience: {options.TokenValidationParameters.ValidateAudience}",
            options.TokenValidationParameters.ValidateAudience);
        _logger.LogInformation("Validate Lifetime: {options.TokenValidationParameters.ValidateLifetime}",
            options.TokenValidationParameters.ValidateLifetime);
        _logger.LogInformation("Validate Issuer Signing Key: {options.TokenValidationParameters.ValidateIssuerSigningKey}",
            options.TokenValidationParameters.ValidateIssuerSigningKey);
        _logger.LogInformation("Valid Issuer: {options.TokenValidationParameters.ValidIssuer}",
            options.TokenValidationParameters.ValidIssuer);
        _logger.LogInformation("Valid Audience: {options.TokenValidationParameters.ValidAudience}",
            options.TokenValidationParameters.ValidAudience);
        _logger.LogInformation("Secret Key: {_settings.SecretKey}",
            _settings.SecretKey);
        _logger.LogInformation("{Environment.NewLine}", Environment.NewLine);
    }
}
