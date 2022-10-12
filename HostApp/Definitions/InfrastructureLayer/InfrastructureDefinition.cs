using Calabonga.AspNetCore.AppDefinitions;
using Becoming.Core.Common.Infrastructure.Services;
using Becoming.Core.TaskManager.Infrastructure.PostgreSql;
using Becoming.Core.Common.Infrastructure.Hangfire;
using Becoming.Core.Common.Infrastructure.Persistence.Constants;
using Becoming.Core.Common.Infrastructure.Settings;
using Becoming.Core.TaskManager.Infrastructure.SqlServer;

namespace HostApp.Definitions.InfrastructureLayer;

public sealed class InfrastructureDefinition : AppDefinition
{
    public override int OrderIndex => 5;

    public override void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder)
    {
        using var scope = services.BuildServiceProvider().CreateScope();
        var configuration = builder.Configuration;

        var environment = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
        var databaseModelOptions = scope.ServiceProvider.GetRequiredService<DatabaseModelOptions>();
        var providerModelOptions = scope.ServiceProvider.GetRequiredService<ProviderModelOptions>();
        var hangfireModelOptions = scope.ServiceProvider.GetRequiredService<HangfireModelOptions>();

        services.AddSharedServicesInfrastructure();
        services.AddHangfireInfrastructure(configuration, environment, hangfireModelOptions, providerModelOptions);

        switch (providerModelOptions.Name)
        {
            case DatebaseSettingConstants.PostgreSqlDatabaseProvider:
                {
                    services.AddTaskManagerPostgreSqlInfrastructure(configuration, environment, databaseModelOptions);
                    break;
                }
            case DatebaseSettingConstants.SqlServerDatabaseProvider:
                {
                    services.AddTaskManagerSqlServerInfrastructure(configuration, environment, databaseModelOptions);
                    break;
                }
        }
    }

    public override void ConfigureApplication(WebApplication app)
    {
        var configuration = app.Configuration;
        var environment = app.Environment;

        var providerModelOptions = app.Services.GetRequiredService<ProviderModelOptions>();

        switch (providerModelOptions.Name)
        {
            case DatebaseSettingConstants.PostgreSqlDatabaseProvider:
                {
                    app.UseTaskManagerPostgreSqlInfrastructure(configuration, environment);
                    break;
                }
            case DatebaseSettingConstants.SqlServerDatabaseProvider:
                {
                    app.UseTaskManagerSqlServerInfrastructure(configuration, environment);
                    break;
                }
        }
    }
}
