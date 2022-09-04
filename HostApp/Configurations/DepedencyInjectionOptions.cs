﻿using Becoming.Core.TaskManager.Application;
using Becoming.Core.TaskManager.Infrastructure;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.Collections.Generic;
using System.Reflection;

namespace HostApp.Configurations;

public static class DepedencyInjectionOptions
{
    public static IServiceCollection AddPresentationControllers(this IServiceCollection services)
    {
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

    public static IServiceCollection AddTaskManager(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTaskManagerApplication(configuration);
        services.AddTaskManagerInfrastructure(configuration);

        return services;
    }
}
