using Becoming.Core.Common.Infrastructure.Persistence.Constants;
using Becoming.Core.Common.Infrastructure.Settings;
using Becoming.Core.TaskManager.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Becoming.Core.TaskManager.Infrastructure.SqlServer;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddTaskManagerInfrastructureSqlServer(this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment environment,
        DatabaseModelOptions modelOptions)
    {
        services.AddDbContext<TaskManagerSqlServerContext>(options =>
        {
            options.UseSqlServer(
                connectionString: configuration.GetConnectionString(DatebaseSettingConstants.SqlServerConnectionSectionName),
                sqlServerOptionsAction: options =>
                {
                    options.CommandTimeout(modelOptions.CommandTimeout);
                    options.EnableRetryOnFailure(
                        maxRetryCount: modelOptions.MaxRetryCount,
                        maxRetryDelay: TimeSpan.FromSeconds(modelOptions.MaxRetryDelay),
                        errorNumbersToAdd: new List<int> { 4060 });
                });

            if (environment.IsDevelopment())
            {
                options.EnableDetailedErrors(modelOptions.EnableDetailedErrors);
                options.EnableSensitiveDataLogging(modelOptions.EnableSensitiveDataLogging);
            }

        }, optionsLifetime: ServiceLifetime.Singleton);

        services.AddScoped<TaskManagerContext, TaskManagerSqlServerContext>();
        services.AddServicesInfrastructure(configuration);

        return services;
    }

    public static IApplicationBuilder UseTaskManagerInfrastructureSqlServer(this IApplicationBuilder app,
        IConfiguration configuration,
        IWebHostEnvironment environment)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        using var context = serviceScope.ServiceProvider.GetService<TaskManagerSqlServerContext>();
        context?.Database.Migrate();

        return app;
    }
}