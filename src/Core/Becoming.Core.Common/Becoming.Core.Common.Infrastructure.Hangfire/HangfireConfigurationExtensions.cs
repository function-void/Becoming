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
        string hfDbConnection = provider.Name switch
        {
            DatebaseSettingConstants.PostgreSqlDatabaseProvider => configuration.GetConnectionString(DatebaseSettingConstants.PostgreSqlConnectionSectionName),
            DatebaseSettingConstants.MSSqlDatabaseProvider => configuration.GetConnectionString(DatebaseSettingConstants.MSSqlConnectionSectionName),
            _ => throw new NotImplementedException(nameof(DatebaseSettingConstants)),
        };

        services.AddHangfire(configuration =>
        {
            configuration.UseMediatR();
            configuration.UseFilter(new AutomaticRetryAttribute { Attempts = modelOptions.MaxRetryCount });

            if (modelOptions.UseInMemory)
                configuration.UseMemoryStorage();
            else
                configuration.UsePostgreSqlStorage(hfDbConnection, new PostgreSqlStorageOptions());
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