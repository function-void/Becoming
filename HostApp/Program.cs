using HostApp.Configurations;
using HostApp.Middleware;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using HostApp.Configurations.Model;
using Microsoft.Extensions.Options;
using HostApp.Configurations.Setup;

var builder = WebApplication.CreateBuilder(args);
{
    // TODO: add option pattern for db context
    var configuration = builder.Configuration;
    builder.Services.AddPresentationControllers();
    builder.Services.AddTaskManager(configuration);

    builder.Services.ConfigureOptions<DatabaseOptionsSetup>();
    builder.Services.ConfigureOptions<JwtModelOptionsSetup>();
    builder.Services.ConfigureOptions<ConfigureApiBehaviorOptions>();
    builder.Services.ConfigureOptions<ConfigureApiExplorerOptions>();
    builder.Services.ConfigureOptions<ConfigureApiVersioningOptions>();
    builder.Services.ConfigureOptions<ConfigureAuthenticationOptions>();
    builder.Services.ConfigureOptions<ConfigureCorsOptions>();
    builder.Services.ConfigureOptions<ConfigureForwardedHeadersOptions>();
    builder.Services.ConfigureOptions<ConfigureJsonOptions>();
    builder.Services.ConfigureOptions<ConfigureJwtBearerOptions>();
    builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

    builder.Services.AddSingleton(x => x.GetService<IOptions<JwtModelOptions>>()!.Value);

    #region authentication
    builder.Services.AddAuthentication().AddJwtBearer();
    #endregion

    #region api
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddApiVersioning();
    builder.Services.AddVersionedApiExplorer();
    builder.Services.AddCors();
    #endregion
}

var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

        foreach (var description in provider.ApiVersionDescriptions)
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName);
    });

    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseCors("CORS_Policy");
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}