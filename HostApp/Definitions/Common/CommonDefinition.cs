using HostApp.Middleware;
using Calabonga.AspNetCore.AppDefinitions;

namespace HostApp.Definitions.Common;

public sealed class CommonDefinition : AppDefinition
{
    public override int OrderIndex => 1;

    public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        #region authentication
        services.AddAuthentication().AddJwtBearer();
        #endregion

        #region api
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddApiVersioning();
        services.AddVersionedApiExplorer();
        services.AddCors();
        #endregion
    }

    public override void ConfigureApplication(WebApplication app, IWebHostEnvironment env)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseForwardedHeaders();
        app.UseMiddleware<ErrorHandlingMiddleware>();
        app.UseCors("CORS_Policy");
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }
}
