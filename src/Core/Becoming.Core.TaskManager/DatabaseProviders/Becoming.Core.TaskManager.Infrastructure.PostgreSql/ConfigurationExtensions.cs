using Becoming.Core.Common.Infrastructure.Persistence.Constants;
using Becoming.Core.TaskManager.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Becoming.Core.TaskManager.Infrastructure.PostgreSql;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddTaskManagerInfrastructurePostgreSql(
        this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment environment,
        dynamic modelOptions
        )
    {
        services.AddEntityFrameworkNpgsql().AddDbContext<TaskManagerPostgreSqlContext>(options =>
        {
            if (environment.IsDevelopment())
            {
                options.EnableDetailedErrors(modelOptions.EnableDetailedErrors);
                options.EnableSensitiveDataLogging(modelOptions.EnableSensitiveDataLogging);
            }
            options.UseNpgsql(
                connectionString: configuration.GetConnectionString(DatebaseSettingConstants.PostgreSqlConnectionSectionName),
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

        services.AddScoped<TaskManagerContext, TaskManagerPostgreSqlContext>();
        services.AddServicesInfrastructure(configuration);

        return services;
    }
}
