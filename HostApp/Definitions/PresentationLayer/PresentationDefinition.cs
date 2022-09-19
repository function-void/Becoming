using System.Reflection;
using Becoming.Core.Common.Presentation;
using Calabonga.AspNetCore.AppDefinitions;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyModel;

namespace HostApp.Definitions.PresentationLayer;

public sealed class PresentationDefinition : AppDefinition
{
    public const string PresentationLayerName = "Presentation";

    public override int OrderIndex => 2;

    public override void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder)
    {
        var presentationAssemblyList = DependencyContext.Default.RuntimeLibraries
            .Where(x => x.Name.Contains(PresentationLayerName))
            .Select(x => Assembly.Load(x.Name))
            .Where(assembly => assembly.DefinedTypes.Where(t => !t.IsAbstract)
                .Any(t => t.BaseType == typeof(ApiController) && t.IsSubclassOf(typeof(ApiController))))
            .ToList();

        services.AddControllers().ConfigureApplicationPartManager(apm =>
        {
            foreach (var assembly in presentationAssemblyList)
            {
                apm.ApplicationParts.Add(new AssemblyPart(assembly));
            }
        }).AddControllersAsServices();
    }
}
