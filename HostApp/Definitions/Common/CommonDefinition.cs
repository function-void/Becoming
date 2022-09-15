using Calabonga.AspNetCore.AppDefinitions;
using HostApp.Middleware;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

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
        app.UseSwaggerUI(options =>
        {
            var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

            foreach (var description in provider.ApiVersionDescriptions)
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName);
        });

        app.UseForwardedHeaders();
        app.UseMiddleware<ErrorHandlingMiddleware>();
        app.UseCors("CORS_Policy");
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }
}
