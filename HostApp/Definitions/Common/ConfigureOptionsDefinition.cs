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

    public override void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder)
    {
        #region setup
        services.ConfigureOptions<DatabaseOptionsSetup>();
        services.ConfigureOptions<JwtOptionsSetup>();
        services.ConfigureOptions<ApiVersioningOptionsSetup>();
        services.ConfigureOptions<HangfireOptionsSetup>();
        services.ConfigureOptions<ProviderOptionsSetup>();
        #endregion

        #region configure options
        services.ConfigureOptions<ConfigureApiBehaviorOptions>();
        services.ConfigureOptions<ConfigureApiExplorerOptions>();
        services.ConfigureOptions<ConfigureApiVersioningOptions>();
        services.ConfigureOptions<ConfigureAuthenticationOptions>();
        services.ConfigureOptions<ConfigureCorsOptions>();
        services.ConfigureOptions<ConfigureMvcOptions>();
        services.ConfigureOptions<ConfigureForwardedHeadersOptions>();
        services.ConfigureOptions<ConfigureJsonOptions>();
        services.ConfigureOptions<ConfigureJwtBearerOptions>();
        services.ConfigureOptions<ConfigureSwaggerOptions>();
        services.ConfigureOptions<ConfigureSwaggerUIOptions>();
        services.ConfigureOptions<ConfigureMiniProfilerOptions>();
        #endregion

        #region register model options
        services.AddSingleton(x => x.GetService<IOptions<JwtModelOptions>>()!.Value);
        services.AddSingleton(x => x.GetService<IOptions<DatabaseModelOptions>>()!.Value);
        services.AddSingleton(x => x.GetService<IOptions<ApiVersioningModelOptions>>()!.Value);
        services.AddSingleton(x => x.GetService<IOptions<HangfireModelOptions>>()!.Value);
        services.AddSingleton(x => x.GetService<IOptions<ProviderModelOptions>>()!.Value);
        #endregion
    }
}
