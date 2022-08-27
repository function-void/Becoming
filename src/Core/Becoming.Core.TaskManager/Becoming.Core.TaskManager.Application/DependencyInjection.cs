using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Becoming.Core.TaskManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddTaskManagerApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
