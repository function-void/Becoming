﻿using Becoming.Core.Common.Infrastructure.Persistence.Constants;
using Becoming.Core.Common.Infrastructure.Settings;
using Becoming.Core.TaskManager.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Becoming.Core.TaskManager.Infrastructure.PostgreSql;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddTaskManagerPostgreSqlInfrastructure(this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment environment,
        DatabaseModelOptions modelOptions)
    {
        services.AddDbContext<TaskManagerPostgreSqlContext>(options =>
        {
            options.UseNpgsql(
                connectionString: configuration.GetConnectionString(DatebaseSettingConstants.PostgreSqlConnectionSectionName),
                npgsqlOptionsAction: options =>
                {
                    options.CommandTimeout(modelOptions.CommandTimeout);
                    options.EnableRetryOnFailure(
                        maxRetryCount: modelOptions.MaxRetryCount,
                        maxRetryDelay: TimeSpan.FromSeconds(modelOptions.MaxRetryDelay),
                        errorCodesToAdd: null);
                });

            if (environment.IsDevelopment())
            {
                options.EnableDetailedErrors(modelOptions.EnableDetailedErrors);
                options.EnableSensitiveDataLogging(modelOptions.EnableSensitiveDataLogging);
            }

        }, optionsLifetime: ServiceLifetime.Singleton);

        services.AddScoped<TaskManagerContext, TaskManagerPostgreSqlContext>();
        services.AddServicesInfrastructure(configuration);

        return services;
    }

    public static IApplicationBuilder UseTaskManagerPostgreSqlInfrastructure(this IApplicationBuilder app,
        IConfiguration configuration,
        IWebHostEnvironment environment)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        using var context = serviceScope.ServiceProvider.GetService<TaskManagerPostgreSqlContext>();
        context?.Database.Migrate();

        return app;
    }
}
