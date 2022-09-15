using HostApp.Configurations.Model;
using Calabonga.AspNetCore.AppDefinitions;
using Becoming.Core.Common.Infrastructure.Services;
using Becoming.Core.TaskManager.Infrastructure.PostgreSql;

namespace HostApp.Definitions.InfrastructureLayer;

public sealed class InfrastructureDefinition : AppDefinition
{
    public override int OrderIndex => 4;

    public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        using var scope = services.BuildServiceProvider().CreateScope();
        var databaseModelOptions = scope.ServiceProvider.GetRequiredService<DatabaseModelOptions>();
        var environment = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

        var providersDic = configuration.GetSection("DatabaseProviders").GetChildren().ToDictionary(x => x.Key, x => x.Value);


        services.AddSharedServicesInfrastructure();

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
