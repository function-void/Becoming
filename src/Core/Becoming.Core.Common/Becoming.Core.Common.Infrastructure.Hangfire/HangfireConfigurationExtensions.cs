using Hangfire;
using Newtonsoft.Json;
using Hangfire.PostgreSql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Becoming.Core.Common.Infrastructure.Hangfire.Persistence;
using Microsoft.EntityFrameworkCore;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Becoming.Core.Common.Infrastructure.Persistence.Constants;

namespace Becoming.Core.Common.Infrastructure.Hangfire;

public static class HangfireConfigurationExtensions
{
    public static IServiceCollection AddHangfireInfrastructurePostgreSql(
        this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment environment,
        dynamic modelOptions
        )
    {
        if (modelOptions.UseInMemory)
        {
            services.AddHangfire(configuration =>
            {
                configuration.UseMediatR();
                configuration.UseMemoryStorage();
                configuration.UseFilter(new AutomaticRetryAttribute { Attempts = modelOptions.MaxRetryCount });
            });
        }
        else
        {
            var hfDbConnection = configuration.GetConnectionString(DbConstants.PostgreSqlConnectionSectionName);
            services.AddEntityFrameworkNpgsql().AddDbContext<HangfireDbContext>(options =>
            {
                if (environment.IsDevelopment())
                {
                    options.EnableDetailedErrors(modelOptions.EnableDetailedErrors);
                    options.EnableSensitiveDataLogging(modelOptions.EnableSensitiveDataLogging);
                }
                options.UseNpgsql(
                    connectionString: hfDbConnection,
                    npgsqlOptionsAction: options =>
                    {
                        options.CommandTimeout(modelOptions.CommandTimeout);
                        options.EnableRetryOnFailure(
                            maxRetryCount: modelOptions.MaxRetryCount,
                            maxRetryDelay: TimeSpan.FromSeconds(modelOptions.MaxRetryDelay),
                            errorCodesToAdd: null
                            );
                    });
            }, ServiceLifetime.Scoped, ServiceLifetime.Singleton);

            services.AddHangfire(configuration =>
            {
                configuration.UseMediatR();
                configuration.UsePostgreSqlStorage(hfDbConnection, new PostgreSqlStorageOptions());
                configuration.UseFilter(new AutomaticRetryAttribute { Attempts = modelOptions.MaxRetryCount });
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