using HostApp.Configurations;
using HostApp.Configurations.Model;
using HostApp.Configurations.Setup;
using Microsoft.Extensions.Options;
using Calabonga.AspNetCore.AppDefinitions;
using Becoming.Core.Common.Infrastructure.Settings;

namespace HostApp.Definitions.Common;

public sealed class ConfigureOptionsDefinition : AppDefinition
{
    public override int OrderIndex => base.OrderIndex;

    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        #region setup
        builder.Services.ConfigureOptions<DatabaseOptionsSetup>();
        builder.Services.ConfigureOptions<JwtOptionsSetup>();
        builder.Services.ConfigureOptions<ApiVersioningOptionsSetup>();
        builder.Services.ConfigureOptions<HangfireOptionsSetup>();
        builder.Services.ConfigureOptions<ProviderOptionsSetup>();
        builder.Services.ConfigureOptions<CorsOptionsSetup>();
        builder.Services.ConfigureOptions<SwaggerOptionsSetup>();
        #endregion

        #region configure options
        builder.Services.ConfigureOptions<ConfigureApiBehaviorOptions>();
        builder.Services.ConfigureOptions<ConfigureApiExplorerOptions>();
        builder.Services.ConfigureOptions<ConfigureApiVersioningOptions>();
        builder.Services.ConfigureOptions<ConfigureAuthenticationOptions>();
        builder.Services.ConfigureOptions<ConfigureCorsOptions>();
        builder.Services.ConfigureOptions<ConfigureMvcOptions>();
        builder.Services.ConfigureOptions<ConfigureForwardedHeadersOptions>();
        builder.Services.ConfigureOptions<ConfigureJsonOptions>();
        builder.Services.ConfigureOptions<ConfigureJwtBearerOptions>();
        builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
        builder.Services.ConfigureOptions<ConfigureSwaggerUIOptions>();
        builder.Services.ConfigureOptions<ConfigureMiniProfilerOptions>();
        #endregion

        #region register model options
        builder.Services.AddSingleton(x => x.GetService<IOptions<JwtModelOptions>>()!.Value);
        builder.Services.AddSingleton(x => x.GetService<IOptions<DatabaseModelOptions>>()!.Value);
        builder.Services.AddSingleton(x => x.GetService<IOptions<ApiVersioningModelOptions>>()!.Value);
        builder.Services.AddSingleton(x => x.GetService<IOptions<HangfireModelOptions>>()!.Value);
        builder.Services.AddSingleton(x => x.GetService<IOptions<ProviderModelOptions>>()!.Value);
        builder.Services.AddSingleton(x => x.GetService<IOptions<CorsModelOptions>>()!.Value);
        builder.Services.AddSingleton(x => x.GetService<IOptions<SwaggerModelOptions>>()!.Value);
        #endregion
    }
}
