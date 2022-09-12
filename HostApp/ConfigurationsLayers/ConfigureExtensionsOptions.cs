using Becoming.Core.Common.Infrastructure.Services;
using Becoming.Core.TaskManager.Application;
using Becoming.Core.TaskManager.Infrastructure;
using Becoming.Core.TaskManager.Infrastructure.PostgreSql;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.Reflection;
using HostApp.Configurations.Model;

namespace HostApp.ConfigurationsLayers;

public static class ConfigureExtensionsOptions
{
    public static IServiceCollection AddPresentationControllers(this IServiceCollection services)
    {
        // TODO: add a reflection with the apicontroller to get list presentation assembly
        var presentationAssemblyList = new List<Assembly>
        {
            typeof(Becoming.Core.Blog.Presentation.AssemblyReference).Assembly,
            typeof(Becoming.Core.TaskManager.Presentation.AssemblyReference).Assembly,
        };

        services.AddControllers().ConfigureApplicationPartManager(apm =>
        {
            foreach (var assembly in presentationAssemblyList)
            {
                apm.ApplicationParts.Add(new AssemblyPart(assembly));
            }
        }).AddControllersAsServices();

        return services;
    }

    public static IServiceCollection AddApllicationLayers(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTaskManagerApplication(configuration);
        return services;
    }

    public static IServiceCollection AddInfrastructureLayers(
        this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment hostEnvironment
        )
    {
        var databaseModelOptions = configuration.Get<DatabaseModelOptions>();
        services.AddSharedServicesInfrastructure();

        if (databaseModelOptions.ProviderName == "PostgreSql")
        {
            services.AddTaskManagerInfrastructure(configuration, hostEnvironment, databaseModelOptions);
        }

        return services;
    }
}