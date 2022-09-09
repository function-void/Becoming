using Becoming.Core.Common.Infrastructure.Persistence.Constants;
using HostApp.Configurations.OptionsModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Becoming.Core.TaskManager.Infrastructure.PostgreSql;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddTaskManagerInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        services.AddEntityFrameworkNpgsql().AddDbContext<TaskManagerPostgreSqlContext>(
            (serviceProvider, options) =>
            {
                var databaseOptions = serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value;

                options.UseNpgsql(
                    connectionString: configuration.GetConnectionString(DbConstants.PostgreSqlConnectionSectionName),
                    npgsqlOptionsAction: options =>
                    {
                        options.EnableRetryOnFailure(
                            maxRetryCount: databaseOptions.MaxRetryCount,
                            maxRetryDelay: TimeSpan.FromSeconds(databaseOptions.MaxRetryDelay),
                            errorCodesToAdd: null
                            );

                        options.CommandTimeout(databaseOptions.CommandTimeout);
                    });

                if (environment.IsDevelopment())
                {
                    options.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
                    options.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
                }
            }, ServiceLifetime.Scoped);

        return services;
    }
}
