using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Becoming.Core.TaskManager.Infrastructure.PostgreSql;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddTaskManagerInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}
