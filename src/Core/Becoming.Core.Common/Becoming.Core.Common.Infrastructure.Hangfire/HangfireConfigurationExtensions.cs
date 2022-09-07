using Hangfire;
using Newtonsoft.Json;
using Hangfire.PostgreSql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Becoming.Core.Common.Infrastructure.Hangfire.Persistence;
using Microsoft.EntityFrameworkCore;
using Hangfire.MemoryStorage;

namespace Becoming.Core.Common.Infrastructure.Hangfire;

public static class HangfireConfigurationExtensions
{
    public static IServiceCollection AddHangfireInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var flag = (bool)configuration.GetValue(typeof(bool), "HangfireUseInMemory");
        if (flag)
        {
            services.AddHangfire(configuration =>
            {
                configuration.UseMemoryStorage();
            });
        }
        else
        {
            var hfDbConnection = configuration.GetConnectionString("DbConstants.HangfireDbSettingsConnectionName");

            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<HangfireDbContext>(opt => opt.UseNpgsql(hfDbConnection));

            services.AddHangfire(configuration =>
            {
                configuration.UseMediatR();
                configuration.UsePostgreSqlStorage(hfDbConnection, new PostgreSqlStorageOptions());
            }).AddHangfireServer();
        }

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