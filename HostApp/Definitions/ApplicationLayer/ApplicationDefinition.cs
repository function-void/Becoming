using Becoming.Core.TaskManager.Application;
using Calabonga.AspNetCore.AppDefinitions;

namespace HostApp.Definitions.ApplicationLayer;

public sealed class ApplicationDefinition : AppDefinition
{
    public override int OrderIndex => 4;

    public override void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddTaskManagerApplication(builder.Configuration);
    }
}