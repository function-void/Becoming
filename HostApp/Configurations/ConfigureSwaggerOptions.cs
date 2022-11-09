using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using HostApp.Configurations.Model;
using Microsoft.Extensions.DependencyInjection;

namespace HostApp.Configurations;

sealed class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
{
    private readonly ILogger<ConfigureSwaggerOptions> _logger;
    private readonly IApiVersionDescriptionProvider _provider;
    private readonly SwaggerModelOptions _settings;

    public ConfigureSwaggerOptions(
        ILogger<ConfigureSwaggerOptions> logger,
        IApiVersionDescriptionProvider provider,
        SwaggerModelOptions settings)
    {
        _logger = logger;
        _provider = provider;
        _settings = settings;
    }

    public void Configure(string? name, SwaggerGenOptions options)
    {
        _logger.LogInformation("{Environment.NewLine}", Environment.NewLine);
        _logger.LogInformation(message: "{nameof(ConfigureSwaggerOptions)} {name} started!",
            nameof(ConfigureSwaggerOptions), name);

        Configure(options);
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
        }

        options.AddSecurityDefinition(_settings.SchemeReferemceId, new OpenApiSecurityScheme()
        {
            Name = _settings.SecuritySchemeName,
            Description = _settings.SchemeDescription,
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http, // ApiKey
            Scheme = JwtBearerDefaults.AuthenticationScheme,
            BearerFormat = _settings.BearerFormat
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = _settings.SchemeReferemceId,
                    },
                }, Array.Empty<string>()
            }
        });

        _logger.LogInformation("{nameof(ConfigureSwaggerOptions)} is configured!",
            nameof(ConfigureSwaggerOptions));
        _logger.LogInformation("Name: {_settings.SecuritySchemeName}",
            _settings.SecuritySchemeName);
        _logger.LogInformation("Description: {_settings.Description}",
            _settings.SchemeDescription);
        _logger.LogInformation("OpenApi SecurityScheme ReferenceId: {_settings.SchemeReferemceId}",
            _settings.SchemeReferemceId);
        _logger.LogInformation("In: {ParameterLocation.Header}",
            ParameterLocation.Header);
        _logger.LogInformation("Type: {SecuritySchemeType.Http}",
            SecuritySchemeType.Http);
        _logger.LogInformation("Scheme: {JwtBearerDefaults.AuthenticationScheme}",
            JwtBearerDefaults.AuthenticationScheme);
        _logger.LogInformation("BearerFormat: {_settings.BearerFormat}",
            _settings.BearerFormat);
        _logger.LogInformation("{Environment.NewLine}", Environment.NewLine);
    }

    private OpenApiInfo CreateVersionInfo(ApiVersionDescription desc)
    {
        return new OpenApiInfo() { Title = _settings.SwaggerTitle, Version = desc.ApiVersion.ToString() };
    }
}