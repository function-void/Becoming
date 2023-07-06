namespace Becoming.Core.Common.Infrastructure.Settings;

public static class DatabaseSetupProvider
{
    public const string SqlServerConnectionSectionName = "SQLServer";
    public const string PostgreSqlConnectionSectionName = "PostgreSQL";

    public const string EventStoreSqlServerConnectionSectionName = "EventStoreSQLServerConnectionString";
    public const string EventStorePostgreSqlConnectionSectionName = "EventStorePostgreSQLConnectionString";

    public const string PostgreSqlDatabaseProvider = "PostgreSql";
    public const string SqlServerDatabaseProvider = "SqlServer";
}
