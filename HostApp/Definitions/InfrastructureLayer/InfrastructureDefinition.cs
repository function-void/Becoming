﻿using Calabonga.AspNetCore.AppDefinitions;
using Becoming.Core.Common.Infrastructure.Services;
using Becoming.Core.TaskManager.Infrastructure.PostgreSql;
using Becoming.Core.Common.Infrastructure.Settings;
using Becoming.Core.TaskManager.Infrastructure.SqlServer;
using Becoming.Core.Common.Infrastructure.Hangfire;
using Becoming.Core.Common.Infrastructure.Settings.ModelOptions;

namespace HostApp.Definitions.InfrastructureLayer;

public sealed class InfrastructureDefinition : AppDefinition
{
    public override int OrderIndex => 5;

    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        using var scope = builder.Services.BuildServiceProvider().CreateScope();
        var configuration = builder.Configuration;

        var environment = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
        var databaseModelOptions = scope.ServiceProvider.GetRequiredService<DatabaseModelOptions>();
        var providerModelOptions = scope.ServiceProvider.GetRequiredService<ProviderModelOptions>();
        var hangfireModelOptions = scope.ServiceProvider.GetRequiredService<HangfireModelOptions>();

        builder.Services.AddSharedServicesInfrastructure();
        builder.Services.AddEventStoreInfrastructure(configuration, hangfireModelOptions, providerModelOptions);

        switch (providerModelOptions.Name)
        {
            case DatabaseSetupProvider.PostgreSqlDatabaseProvider:
                {
                    builder.Services.AddTaskManagerPostgreSqlInfrastructure(configuration, environment, databaseModelOptions);
                    break;
                }
            case DatabaseSetupProvider.SqlServerDatabaseProvider:
                {
                    builder.Services.AddTaskManagerSqlServerInfrastructure(configuration, environment, databaseModelOptions);
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
            case DatabaseSetupProvider.PostgreSqlDatabaseProvider:
                {
                    app.UseTaskManagerPostgreSqlInfrastructure(configuration, environment);
                    break;
                }
            case DatabaseSetupProvider.SqlServerDatabaseProvider:
                {
                    app.UseTaskManagerSqlServerInfrastructure(configuration, environment);
                    break;
                }
        }
    }
}
