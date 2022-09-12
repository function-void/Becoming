using Becoming.Core.Common.Infrastructure.Services;
using Becoming.Core.TaskManager.Application;
using Becoming.Core.TaskManager.Infrastructure.PostgreSql;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.Reflection;
using HostApp.Configurations.Model;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Becoming.Core.Common.Infrastructure.Routing;

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

        services.AddControllers(options =>
        {
            options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()))
        })
        .ConfigureApplicationPartManager(apm =>
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

    public static IServiceCollection AddInfrastructureLayers(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment hostEnvironment)
    {
        using var scope = services.BuildServiceProvider().CreateScope();
        var databaseModelOptions = scope.ServiceProvider.GetRequiredService<DatabaseModelOptions>();
        var providerNames = configuration.GetSection("DatabaseProviders").GetChildren().Select(x => x.Value).ToList();

        services.AddSharedServicesInfrastructure();

        switch (databaseModelOptions.ProviderName)
        {
            case "PostgreSql":
                {
                    services.AddTaskManagerInfrastructurePostgreSql(configuration, hostEnvironment, databaseModelOptions);
                    break;
                }
            case "MicrosoftSQLServer":
                {
                    break;
                }
        }

        return services;
    }
}