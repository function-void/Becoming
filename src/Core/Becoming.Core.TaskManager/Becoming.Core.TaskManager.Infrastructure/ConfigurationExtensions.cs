using System.Reflection;
using Becoming.Core.TaskManager.Application;
using Becoming.Core.TaskManager.Domain.Root;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Becoming.Core.TaskManager.Infrastructure;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddServicesInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITaskManagerRepository, TaskManagerRepository>();
        services.AddScoped<ITaskManagerFactory, TaskManagerFactory>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}
