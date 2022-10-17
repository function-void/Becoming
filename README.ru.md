# Becoming
    Архитектура - модульный монолит (ASP NET Core 6 Web Api). 
    Поддержка баз данных: PostgreSQL, MsSSQL. 
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

#### Видео:
 * [Модульный монолит вместо микросервисов](https://www.youtube.com/watch?v=4UKjtzeQ_uc&)

#### Примеры кода:
 * [Modular Monolith with DDD](https://github.com/kgrzybek/modular-monolith-with-ddd)

## О проекте

## Запуск
Локально! В [appsettings.json](./HostApp/appsettings.json) выбрать провайдера из
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
Пример строки в Manage User Secrets
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
## Лицензия