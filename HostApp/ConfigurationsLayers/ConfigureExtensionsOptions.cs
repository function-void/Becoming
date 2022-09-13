using Becoming.Core.Common.Infrastructure.Services;
using Becoming.Core.TaskManager.Application;
using Becoming.Core.TaskManager.Infrastructure.PostgreSql;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.Reflection;
using HostApp.Configurations.Model;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Becoming.Core.Common.Infrastructure.Routing;
using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Becoming.Core.Common.Presentation;
using System.Linq;

namespace HostApp.ConfigurationsLayers;

public static class ConfigureExtensionsOptions
{
    public static IServiceCollection AddPresentationControllers(this IServiceCollection services)
    {
        var presentationAssemblyList = Assembly
            .GetExecutingAssembly().GetReferencedAssemblies()
            .Select(x => Assembly.Load(x))
            .Where(x => x.DefinedTypes.Where(x => !x.IsAbstract)
                .Any(x => x.BaseType == typeof(ApiController)))
            .ToList();

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

    public static IServiceCollection AddInfrastructureLayers(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment hostEnvironment)
    {
        using var scope = services.BuildServiceProvider().CreateScope();
        var databaseModelOptions = scope.ServiceProvider.GetRequiredService<DatabaseModelOptions>();
        var providersDic = configuration
            .GetSection("DatabaseProviders")
            .GetChildren()
            .ToDictionary(x => x.Key, x => x.Value);

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