using HostApp.Configurations.Model;
using Calabonga.AspNetCore.AppDefinitions;
using Becoming.Core.Common.Infrastructure.Services;
using Becoming.Core.TaskManager.Infrastructure.PostgreSql;
using Becoming.Core.Common.Infrastructure.Hangfire;

namespace HostApp.Definitions.InfrastructureLayer;

public sealed class InfrastructureDefinition : AppDefinition
{
    public override int OrderIndex => 4;

    public override void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder)
    {
        using var scope = services.BuildServiceProvider().CreateScope();
        var databaseModelOptions = scope.ServiceProvider.GetRequiredService<DatabaseModelOptions>();
        var hangfireModelOptions = scope.ServiceProvider.GetRequiredService<HangfireModelOptions>();
        var environment = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
        var configuration = builder.Configuration;

        var providersDic = configuration.GetSection("DatabaseProviders").GetChildren().ToDictionary(x => x.Key, x => x.Value);

        services.AddSharedServicesInfrastructure();
        services.AddHangfireInfrastructure(configuration, environment, hangfireModelOptions);

        switch (databaseModelOptions.ProviderName)
        {
            case "PostgreSql":
                {
                    services.AddTaskManagerInfrastructurePostgreSql(configuration, environment, databaseModelOptions);
                    break;
                }
            case "MicrosoftSQLServer":
                {
                    break;
                }
        }
    }
}
