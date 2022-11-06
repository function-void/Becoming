using HostApp.Middleware;
using Calabonga.AspNetCore.AppDefinitions;
using Hangfire;

namespace HostApp.Definitions.Common;

public sealed class CommonDefinition : AppDefinition
{
    public override int OrderIndex => 1;

    public override void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder)
    {
        #region authentication
        services.AddAuthentication().AddJwtBearer();
        #endregion

        #region healthy
        services.AddHealthChecks();
        services.AddMiniProfiler().AddEntityFramework();
        #endregion

        #region api
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddApiVersioning();
        services.AddVersionedApiExplorer();
        #endregion
    }

    public override void ConfigureApplication(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseMiniProfiler();
        app.MapHealthChecks("/health");
        app.UseHangfireDashboard();

        app.UseForwardedHeaders();
        app.UseMiddleware<ErrorHandlingMiddleware>();
        app.UseHsts();
        app.UseHttpsRedirection();
        //app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
    }
}
