using Becoming.Core.Common.Application.Concept;
using Becoming.Core.Common.Infrastructure.Hangfire.Persistence;
using Becoming.Core.Common.Infrastructure.Hangfire.Services;
using Becoming.Core.Common.Infrastructure.Settings;
using Becoming.Core.Common.Infrastructure.Settings.ModelOptions;
using Hangfire;
using Hangfire.MemoryStorage;
using Hangfire.PostgreSql;
using Hangfire.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Becoming.Core.Common.Infrastructure.Hangfire;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddEventStoreInfrastructure(this IServiceCollection services,
        IConfiguration configuration,
        HangfireModelOptions hangfireModelOptions,
        ProviderModelOptions providerModelOptions)
    {
        services.AddScoped(typeof(IProjector), typeof(Projector));

        if (hangfireModelOptions.UseInMemory)
        {
            services.AddDbContext<EventStoreContext>(options => options.UseInMemoryDatabase("EventStoreDbInMemory"));
            services.AddHangfire(conf =>
            {
                conf.UseMediatR();
                conf.UseFilter(new AutomaticRetryAttribute { Attempts = hangfireModelOptions.MaxRetryCount });
                conf.UseMemoryStorage();
            }).AddHangfireServer();

            return services;
        }

        string connectionString = providerModelOptions.Name switch
        {
            DatabaseSetupProvider.PostgreSqlDatabaseProvider
                => configuration.GetConnectionString(DatabaseSetupProvider.EventStorePostgreSqlConnectionSectionName)!,
            DatabaseSetupProvider.SqlServerDatabaseProvider
                => configuration.GetConnectionString(DatabaseSetupProvider.EventStoreSqlServerConnectionSectionName)!,
            _ => throw new NotImplementedException(nameof(DatabaseSetupProvider)),
        };

        services.AddDbContext<EventStoreContext>(options =>
        {
            options.UseNpgsql(connectionString);
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        services.AddHangfire(conf =>
        {
            conf.UseMediatR();
            conf.UseFilter(new AutomaticRetryAttribute { Attempts = hangfireModelOptions.MaxRetryCount });
            switch (providerModelOptions.Name)
            {
                case DatabaseSetupProvider.PostgreSqlDatabaseProvider:
                    conf.UsePostgreSqlStorage(connectionString, new PostgreSqlStorageOptions()
                    {
                        SchemaName = Scheme.EventsSchemaName
                    });
                    break;
                case DatabaseSetupProvider.SqlServerDatabaseProvider:
                    conf.UseSqlServerStorage(connectionString, new SqlServerStorageOptions()
                    {
                        SchemaName = Scheme.EventsSchemaName
                    });
                    break;
                default: throw new NotImplementedException(nameof(DatabaseSetupProvider));
            }
        }).AddHangfireServer();

        return services;
    }

    public static void UseMediatR(this IGlobalConfiguration configuration)
    {
        var jsonSettings = new JsonSerializerSettings
        {
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
            TypeNameHandling = TypeNameHandling.Objects,
            Formatting = Formatting.Indented,
        };

        configuration.UseSerializerSettings(jsonSettings);
    }
}
