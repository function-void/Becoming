using Calabonga.AspNetCore.AppDefinitions;
using HostApp.Configurations.Model;
using HostApp.Configurations.Setup;
using HostApp.Configurations;
using Microsoft.Extensions.Options;

namespace HostApp.Definitions.Common;

public sealed class ConfigureOptionsDefinition : AppDefinition
{
    public override int OrderIndex => base.OrderIndex;

    public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        #region setup
        services.ConfigureOptions<DatabaseOptionsSetup>();
        services.ConfigureOptions<JwtModelOptionsSetup>();
        services.ConfigureOptions<ApiVersioningModelOptionsSetup>();
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
        #endregion

        #region register model options
        services.AddSingleton(x => x.GetService<IOptions<JwtModelOptions>>()!.Value);
        services.AddSingleton(x => x.GetService<IOptions<DatabaseModelOptions>>()!.Value);
        services.AddSingleton(x => x.GetService<IOptions<ApiVersioningModelOptions>>()!.Value);
        #endregion
    }
}
