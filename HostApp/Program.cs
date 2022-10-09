using Calabonga.AspNetCore.AppDefinitions;

// TODO: add option pattern for db context. +
// TODO: add hangfire. +
// TODO: add validation for IConfigureNamedOptions with IValidateOptions. !
// TODO: add CQRS. !
// TODO: the query boundary in CQRS use repository pattern. !
// TODO: add result error wrapper for perfomance in query boundary. !
// TODO: the command boundary in CQRS use error exception. +

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDefinitions(builder, typeof(Program));
}

var app = builder.Build();
{
    app.UseDefinitions();
    app.Run();
}