using Calabonga.AspNetCore.AppDefinitions;

// TODO: add option pattern for db context
// TODO: add validation for IConfigureNamedOptions with IValidateOptions
// TODO: add hangfire


var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDefinitions(builder, typeof(Program));
}

var app = builder.Build();
{
    app.UseDefinitions();
    app.Run();
}