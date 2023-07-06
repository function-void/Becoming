using Becoming.Core.TaskManager.Application;
using Becoming.Core.TaskManager.Domain.Repositories;
using Becoming.Core.TaskManager.Infrastructure.Persistence;
using Becoming.Core.TaskManager.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Becoming.Core.TaskManager.Infrastructure;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddServicesInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITaskManagerRepository, TaskManagerRepository>();
        services.AddScoped<IQueryTaskManagerRepository, QueryTaskManagerRepository>();

        services.AddScoped<ITaskManagerFactory, TaskManagerFactory>();

        return services;
    }
}
