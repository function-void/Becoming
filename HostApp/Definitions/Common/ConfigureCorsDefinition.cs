using Calabonga.AspNetCore.AppDefinitions;
using HostApp.Configurations.Model;

namespace HostApp.Definitions.Common;

public sealed class ConfigureCorsDefinition : AppDefinition
{
    public override int OrderIndex => 2;

    public override void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddCors();
    }

    public override void ConfigureApplication(WebApplication app)
    {
        var options = app.Services.GetRequiredService<CorsModelOptions>();
        app.UseCors(options.Policy);
    }
}
