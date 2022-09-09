using Becoming.Core.TaskManager.Domain.Repositories;
using Becoming.Core.TaskManager.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Becoming.Core.TaskManager.Infrastructure;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddTaskManagerInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<ITaskManagerRepository, TaskManagerRepository>();

        return services;
    }
}
