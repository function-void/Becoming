using Calabonga.AspNetCore.AppDefinitions;

// TODO: add option pattern for db context

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDefinitions(builder, typeof(Program));
}

var app = builder.Build();
{
    app.UseDefinitions();
    app.Run();
}