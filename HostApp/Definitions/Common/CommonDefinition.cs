using HostApp.Middleware;
using Calabonga.AspNetCore.AppDefinitions;
using Hangfire;
using Becoming.Core.Common.Presentation.Tools.Attributes;

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

        //builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options => {
        //    options.JsonSerializerOptions.IncludeFields = true;
        //});

        builder.Services.AddScoped<DataTransferObjecFilterAttribute>();
        #endregion
    }

    public override void ConfigureApplication(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseMiniProfiler();
        app.UseHangfireDashboard("/event-store", new DashboardOptions
        {
            DashboardTitle = "Becoming EventStore",
            DefaultRecordsPerPage = 40,
            //DisplayNameFunc = ""
        });
        app.MapHealthChecks("/health");

        app.UseHttpsRedirection();
        app.UseForwardedHeaders();
        app.UseMiddleware<ErrorHandlingMiddleware>();
        //app.UseMiddleware<DataTransferObjectMiddleware>();
        app.UseHsts();
        //app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
    }
}
