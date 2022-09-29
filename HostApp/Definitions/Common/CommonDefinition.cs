﻿using HostApp.Middleware;
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

        services.AddHealthChecks();
        services.AddMiniProfiler(options => options.RouteBasePath = "/profiler").AddEntityFramework();

        #region api
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddApiVersioning();
        services.AddVersionedApiExplorer();
        services.AddCors();
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
        app.UseCors("CORS_Policy");
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }
}
