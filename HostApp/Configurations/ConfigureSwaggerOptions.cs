using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Runtime;
using System.Net;

namespace HostApp.Configurations;

public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
{
    private readonly ILogger<ConfigureSwaggerOptions> _logger;
    private readonly IApiVersionDescriptionProvider _provider;

    public ConfigureSwaggerOptions(ILogger<ConfigureSwaggerOptions> logger, IApiVersionDescriptionProvider provider)
    {
        _logger = logger;
        _provider = provider;
    }

    public void Configure(string name, SwaggerGenOptions options)
    {
        _logger.LogInformation(Environment.NewLine);
        _logger.LogInformation(message: $"{nameof(ConfigureSwaggerOptions)} {name} started!");
        Configure(options);
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
        }

        options.AddSecurityDefinition("Bearer_Auth", new OpenApiSecurityScheme()
        {
            Description = "Jwt Bearer Authorization",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http, //ApiKey
            Scheme = JwtBearerDefaults.AuthenticationScheme,
            BearerFormat = "JWT"
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer_Auth",
                    },
                }, Array.Empty<string>()
            }
        });

        _logger.LogInformation($"{nameof(ConfigureSwaggerOptions)} is configured!");
        _logger.LogInformation($"Description: {"Jwt Bearer Authorization"}");
        _logger.LogInformation($"Name: {"Authorization"}");
        _logger.LogInformation($"In: {ParameterLocation.Header}");
        _logger.LogInformation($"Type: {SecuritySchemeType.Http}");
        _logger.LogInformation($"Scheme: {JwtBearerDefaults.AuthenticationScheme}");
        _logger.LogInformation($"BearerFormat: {"JWT"}");
        _logger.LogInformation(Environment.NewLine);
    }

    private OpenApiInfo CreateVersionInfo(ApiVersionDescription desc)
    {
        return new OpenApiInfo() { Title = "Becoming - .NET Core (.NET 6) Web API", Version = desc.ApiVersion.ToString() };
    }
}