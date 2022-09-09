using HostApp.Configurations;
using HostApp.Middleware;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using HostApp.Configurations.Model;
using Microsoft.Extensions.Options;
using HostApp.Configurations.Setup;

var builder = WebApplication.CreateBuilder(args);
{
    var configuration = builder.Configuration;
    builder.Services.AddPresentationControllers();
    builder.Services.AddTaskManager(configuration);

    builder.Services.ConfigureOptions<DatabaseOptionsSetup>();
    builder.Services.ConfigureOptions<JwtModelOptionsSetup>();
    builder.Services.ConfigureOptions<ConfigureJwtBearerOptions>();
    builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

    builder.Services.AddSingleton(x => x.GetService<IOptions<JwtModelOptions>>()!.Value);

    builder.Services.Configure<ApiBehaviorOptions>(options =>
        options.SuppressModelStateInvalidFilter = true
        );

    builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
        options.SerializerOptions.IncludeFields = true
        );

    builder.Services.Configure<ForwardedHeadersOptions>(options =>
            options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        );

    #region authentication

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer();
    #endregion

    #region api
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddApiVersioning(options =>
    {
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
        options.ReportApiVersions = true;
        options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());
    })
    .AddVersionedApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    })
    .AddCors(options =>
    {
        options.AddPolicy("CORS_Policy", builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
    });
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