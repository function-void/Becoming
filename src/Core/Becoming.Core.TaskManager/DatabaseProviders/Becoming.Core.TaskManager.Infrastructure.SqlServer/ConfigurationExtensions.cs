using Becoming.Core.Common.Application.Concept;
using Becoming.Core.Common.Infrastructure.Settings;
using Becoming.Core.Common.Infrastructure.Settings.ModelOptions;
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
    public static IServiceCollection AddTaskManagerSqlServerInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment environment,
        DatabaseModelOptions modelOptions)
    {
        services.AddDbContextPool<TaskManagerSqlServerContext>(options =>
        {
            options.UseSqlServer(
                connectionString: configuration.GetConnectionString(DatabaseSetupProvider.SqlServerConnectionSectionName),
                sqlServerOptionsAction: options =>
                {
                    if (!modelOptions.MultipleQueriesWithinOneTransaction)
                        options.CommandTimeout(modelOptions.CommandTimeout).EnableRetryOnFailure(
                            maxRetryCount: modelOptions.MaxRetryCount,
                            maxRetryDelay: TimeSpan.FromSeconds(modelOptions.MaxRetryDelay),
                            errorNumbersToAdd: new List<int> { 4060 });
                });

            if (environment.IsDevelopment())
            {
                options.EnableDetailedErrors(modelOptions.EnableDetailedErrors);
                options.EnableSensitiveDataLogging(modelOptions.EnableSensitiveDataLogging);
            }
        });

        services.AddScoped<TaskManagerContext, TaskManagerSqlServerContext>();
        services.AddScoped<IUnitOfWork, TaskManagerSqlServerContext>();
        services.AddServicesInfrastructure(configuration);
        return services;
    }

    public static IApplicationBuilder UseTaskManagerSqlServerInfrastructure(
        this IApplicationBuilder app,
        IConfiguration configuration,
        IWebHostEnvironment environment)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        using var context = serviceScope.ServiceProvider.GetRequiredService<TaskManagerSqlServerContext>();
        if (context!.Database.GetPendingMigrations().Any()) context.Database.Migrate();
        return app;
    }
}