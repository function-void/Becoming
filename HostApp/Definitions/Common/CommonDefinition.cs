using HostApp.Middleware;
using Calabonga.AspNetCore.AppDefinitions;
using Hangfire;

namespace HostApp.Definitions.Common;

public sealed class CommonDefinition : AppDefinition
{
    public override int OrderIndex => 1;

    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        #region authentication
        builder.Services.AddAuthentication().AddJwtBearer();
        #endregion

        #region healthy
        builder.Services.AddHealthChecks();
        builder.Services.AddMiniProfiler().AddEntityFramework();
        #endregion

        #region api
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddApiVersioning();
        builder.Services.AddVersionedApiExplorer();
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
