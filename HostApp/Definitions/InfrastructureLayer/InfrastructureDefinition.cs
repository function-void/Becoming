using HostApp.Configurations.Model;
using Calabonga.AspNetCore.AppDefinitions;
using Becoming.Core.Common.Infrastructure.Services;
using Becoming.Core.TaskManager.Infrastructure.PostgreSql;
using Becoming.Core.Common.Infrastructure.Hangfire;
using Becoming.Core.Common.Infrastructure.Persistence.Constants;
using Becoming.Core.Common.Infrastructure.Settings;

namespace HostApp.Definitions.InfrastructureLayer;

public sealed class InfrastructureDefinition : AppDefinition
{
    public override int OrderIndex => 4;

    public override void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder)
    {
        using var scope = services.BuildServiceProvider().CreateScope();
        var configuration = builder.Configuration;

        var environment = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
        var databaseModelOptions = scope.ServiceProvider.GetRequiredService<DatabaseModelOptions>();
        var hangfireModelOptions = scope.ServiceProvider.GetRequiredService<HangfireModelOptions>();

        services.AddSharedServicesInfrastructure();
        services.AddHangfireInfrastructure(configuration, environment, hangfireModelOptions);

        switch (databaseModelOptions.ProviderName)
        {
            case DatebaseSettingConstants.PostgreSqlDatabaseProvider:
                {
                    services.AddTaskManagerInfrastructurePostgreSql(configuration, environment, databaseModelOptions);
                    break;
                }
            case DatebaseSettingConstants.MSSqlDatabaseProvider:
                {
                    break;
                }
        }
    }
}
