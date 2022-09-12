using Becoming.Core.Common.Infrastructure.Persistence.Constants;
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
        services.AddEntityFrameworkNpgsql().AddDbContext<TaskManagerPostgreSqlContext>(
            (serviceProvider, options) =>
            {
                options.UseNpgsql(
                    connectionString: configuration.GetConnectionString(DbConstants.PostgreSqlConnectionSectionName),
                    npgsqlOptionsAction: options =>
                    {
                        options.EnableRetryOnFailure(
                            maxRetryCount: modelOptions.MaxRetryCount,
                            maxRetryDelay: TimeSpan.FromSeconds(modelOptions.MaxRetryDelay),
                            errorCodesToAdd: null
                            );

                        options.CommandTimeout(modelOptions.CommandTimeout);
                    });

                if (environment.IsDevelopment())
                {
                    options.EnableDetailedErrors(modelOptions.EnableDetailedErrors);
                    options.EnableSensitiveDataLogging(modelOptions.EnableSensitiveDataLogging);
                }
            }, ServiceLifetime.Scoped);


        services.RegisterTaskManagerServiceInfrastructure(configuration);

        return services;
    }
}
