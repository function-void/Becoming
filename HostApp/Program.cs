using Calabonga.AspNetCore.AppDefinitions;

// TODO: add option pattern for db context. +
// TODO: add hangfire. +
// TODO: add validation for IConfigureNamedOptions with IValidateOptions. !
// TODO: add CQRS. !
// TODO: the query boundary in CQRS use repository pattern. !
// TODO: add result error wrapper for perfomance in query boundary. !
// TODO: the command boundary in CQRS use error exception. +
// TODO: add functionality after used creat command, and call up event aggregate send notification !

// TODO: добавить возможность обмена событий между агрегатами. Функционал внешний
// TODO: между агрегатом и его дочерними объектами. Функционал внутренний
// TODO: aggregate 1 -> aggregate 2; aggregate 2 -> aggregate 1 child 1 -> aggregate 1
// TODO: add event table
// TODO: add in query repository context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDefinitions(builder, typeof(Program));
}

var app = builder.Build();
{
    app.UseDefinitions();
    app.Run();
}