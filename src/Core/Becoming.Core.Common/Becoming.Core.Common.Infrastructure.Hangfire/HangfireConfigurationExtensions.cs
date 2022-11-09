using Hangfire;
using Newtonsoft.Json;
using Hangfire.PostgreSql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Hosting;
using Becoming.Core.Common.Infrastructure.Persistence.Constants;
using Becoming.Core.Common.Infrastructure.Settings;
using Hangfire.SqlServer;

namespace Becoming.Core.Common.Infrastructure.Hangfire;

public static class HangfireConfigurationExtensions
{
    public static IServiceCollection AddHangfireInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment environment,
        HangfireModelOptions modelOptions,
        ProviderModelOptions provider
        )
    {
        services.AddHangfire(conf =>
        {
            conf.UseMediatR();
            conf.UseFilter(new AutomaticRetryAttribute { Attempts = modelOptions.MaxRetryCount });

            if (modelOptions.UseInMemory)
                conf.UseMemoryStorage();

            switch (provider.Name)
            {
                case DatebaseSettingConstants.PostgreSqlDatabaseProvider:
                    var postgreSqlConnectionString = configuration.GetConnectionString(DatebaseSettingConstants.PostgreSqlConnectionSectionName);
                    conf.UsePostgreSqlStorage(postgreSqlConnectionString, new PostgreSqlStorageOptions());
                    break;
                case DatebaseSettingConstants.SqlServerDatabaseProvider:
                    var sqlServcerConnectionString = configuration.GetConnectionString(DatebaseSettingConstants.SqlServerConnectionSectionName);
                    conf.UseSqlServerStorage(sqlServcerConnectionString, new SqlServerStorageOptions());
                    break;
                default: throw new NotImplementedException(nameof(DatebaseSettingConstants));
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