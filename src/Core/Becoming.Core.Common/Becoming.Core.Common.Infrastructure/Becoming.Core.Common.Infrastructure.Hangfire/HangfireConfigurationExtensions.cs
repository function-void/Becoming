using Becoming.Core.Common.Infrastructure.Settings;
using Hangfire;
using Hangfire.MemoryStorage;
using Hangfire.PostgreSql;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Becoming.Core.Common.Infrastructure.Hangfire;

public static class HangfireConfigurationExtensions
{
    public static IServiceCollection AddHangfireInfrastructure(this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment environment,
        HangfireModelOptions modelOptions,
        ProviderModelOptions provider)
    {
        services.AddHangfire(conf =>
        {
            conf.UseMediatR();
            conf.UseFilter(new AutomaticRetryAttribute { Attempts = modelOptions.MaxRetryCount });

            if (modelOptions.UseInMemory) conf.UseMemoryStorage();
            else switch (provider.Name)
                {
                    case SetupProvider.PostgreSqlDatabaseProvider:
                        var postgreSqlConnectionString = configuration.GetConnectionString(SetupProvider.PostgreSqlConnectionSectionName);
                        conf.UsePostgreSqlStorage(postgreSqlConnectionString, new PostgreSqlStorageOptions());
                        break;
                    case SetupProvider.SqlServerDatabaseProvider:
                        var sqlServcerConnectionString = configuration.GetConnectionString(SetupProvider.SqlServerConnectionSectionName);
                        conf.UseSqlServerStorage(sqlServcerConnectionString, new SqlServerStorageOptions());
                        break;
                    default: throw new NotImplementedException(nameof(SetupProvider));
                }
        }).AddHangfireServer();

        return services;
    }

    public static void UseMediatR(this IGlobalConfiguration configuration)
    {
        var jsonSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };
        configuration.UseSerializerSettings(jsonSettings);
    }
}
