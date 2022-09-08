using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Becoming.Core.TaskManager.Infrastructure;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddTaskManagerInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        return services;
    }
}
