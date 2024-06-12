using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using MediatR.NotificationPublishers;

namespace Becoming.Core.TaskManager.Application;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddTaskManagerApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.NotificationPublisher = new TaskWhenAllPublisher();
            cfg.NotificationPublisherType = typeof(TaskWhenAllPublisher);
        });

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
