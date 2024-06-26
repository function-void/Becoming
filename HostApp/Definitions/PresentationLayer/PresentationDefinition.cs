﻿using System.Reflection;
using Becoming.Core.Common.Presentation.Tools;
using Calabonga.AspNetCore.AppDefinitions;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyModel;

namespace HostApp.Definitions.PresentationLayer;

public sealed class PresentationDefinition : AppDefinition
{
    public const string PresentationLayerName = "Presentation";

    public override int OrderIndex => 3;

    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        var presentationAssemblyList = DependencyContext.Default!.RuntimeLibraries
            .Where(x => x.Name.Contains(PresentationLayerName))
            .Select(x => Assembly.Load(x.Name))
            .Where(assembly => assembly.DefinedTypes.Where(t => !t.IsAbstract)
                .Any(t => t.BaseType == typeof(ApiController) && t.IsSubclassOf(typeof(ApiController))))
            .ToList();

        builder.Services.AddControllers().ConfigureApplicationPartManager(apm =>
        {
            foreach (var assembly in presentationAssemblyList)
            {
                apm.ApplicationParts.Add(new AssemblyPart(assembly));
            }
        }).AddControllersAsServices();
    }
}
