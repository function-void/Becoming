# Becoming
    Архитектура - модульный монолит (ASP NET Core 6 Web Api). 
    Поддержка баз данных: PostgreSQL, MSSQL. 
    CQRS, DDD, Options pattern, MediatR, Hangfire, Clean Architecture

### Расположение
 * [Модульный хост (Module Startup)](./HostApp/)
 * [Модули - ядро](./src/Core/)
 * [Внешние микросервисы](./src/External/)
 * [Шлюз API (ApiGateway)](./src/External/ApiGateway/)
 * [Тесты](./test/)

 ## Ссылки

#### Статьи:
 * [Модульный монолит. Начало](https://habr.com/ru/company/dododev/blog/650721/)
 * [Modular Monolith: Domain-Centric Design](http://www.kamilgrzybek.com/design/modular-monolith-domain-centric-design/)
 * [Implement API Gateways with Ocelot](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/implement-api-gateways-with-ocelot)
 * [Options pattern in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options)
 * [CQRS](https://learn.microsoft.com/en-us/azure/architecture/patterns/cqrs)
 * [MediatR](https://code-maze.com/cqrs-mediatr-in-aspnet-core/)
 * [RFC 7231](https://www.rfc-editor.org/rfc/rfc7231)
 * [Design a DDD-oriented microservice](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice)
 * [Docker + ASP NET Core](https://code.visualstudio.com/docs/containers/quickstart-aspnet-core)
 * [How to Use Mini Profiler in ASP.NET Core Web API](https://dotnetthoughts.net/using-miniprofiler-in-aspnetcore-webapi/)
 * [IDesignTimeDbContextFactory part 1](https://www.brightertools.com/post/idesigntimedbcontextfactory-update-for-entity-framework-6-migrations-design-time-tools-net-core-6)
 * [IDesignTimeDbContextFactory part 2](https://snede.net/you-dont-need-a-idesigntimedbcontextfactory/)
 * [Markdown](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet)
 * [Basic writing and formatting syntax](https://docs.github.com/en/get-started/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax)

#### Видео:
 * [Модульный монолит вместо микросервисов](https://www.youtube.com/watch?v=4UKjtzeQ_uc&)
 * [Многоликий DDD](https://www.youtube.com/watch?v=2WHarUW0PjI)
 * [Don't be fooled! That's NOT an Aggregate in Domain Driven Design](https://www.youtube.com/watch?v=LyRvB6m_uoA)
 * [Docker для Начинающих - Полный Курс](https://www.youtube.com/watch?v=n9uCgUzfeRQ)

#### Примеры кода:
 * [Modular Monolith with DDD](https://github.com/kgrzybek/modular-monolith-with-ddd)

## О проекте

## Запуск
> Local

В [appsettings.json](./HostApp/appsettings.json) выбрать провайдера из
``` json
"DatabaseProviders": {
    "PostgreSqlDatabaseProvider": "PostgreSql",
    "SqlServerDatabaseProvider": "SqlServer"
  },
```
И заполнить в "ProviderModelOptions" значение провайдера по выбору
``` json
"ProviderModelOptions": "PostgreSql",
```
Далее заполняем значение connection string.
``` json
"ConnectionStrings": {
    "PostgreSqlConnectionString": "",
    "SqlServerConnectionString": ""
  },
```
Пример в Manage User Secrets
``` json
"ConnectionStrings": {
    "PostgreSqlConnectionString": "Host=localhost;Port=5432;Database=becoming;Username=postgres;Password=postgres"
  },
  "JwtModelOptions": {
    "SecretKey": "SecretKey",
    "ExpiryMinutes": 3600,
    "Issuer": "Issuer",
    "Audience": "Issuer"
  }
```

Работа с миграциями
``` powershell
Add-Migration Init -Args 'connectionString "Host=localhost;Port=5432;Database=becoming;Username=postgres;Password=postgres'

Update-Database -Args "Host=localhost;Port=5432;Database=becoming;Username=postgres;Password=postgres"
```
## Лицензия