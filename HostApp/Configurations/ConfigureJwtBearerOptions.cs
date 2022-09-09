using HostApp.Configurations.OptionsModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HostApp.Configurations;

public class ConfigureJwtBearerOptions : IConfigureNamedOptions<JwtBearerOptions>
{
    private readonly ILogger<ConfigureJwtBearerOptions> _logger;
    private readonly JwtOptions _jwtSettings;

    public ConfigureJwtBearerOptions(ILogger<ConfigureJwtBearerOptions> logger, JwtOptions jwtSettings)
    {
        _logger = logger;
        _jwtSettings = jwtSettings;
    }

    public void Configure(string name, JwtBearerOptions options)
    {
        options.SaveToken = _jwtSettings.SaveToken;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = _jwtSettings.ValidateIssuer,
            ValidateAudience = _jwtSettings.ValidateAudience,
            ValidateLifetime = _jwtSettings.ValidateLifetime,
            ValidateIssuerSigningKey = _jwtSettings.ValidateIssuerSigningKey,
            ValidIssuer = _jwtSettings.Issuer,
            ValidAudience = _jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey))
        };
    }

    public void Configure(JwtBearerOptions options)
    {
        Configure(JwtBearerDefaults.AuthenticationScheme, options);
    }
}
