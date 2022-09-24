namespace Becoming.Core.Common.Infrastructure.Persistence.Constants;

public static class DatebaseSettingConstants
{
    #region
    public const string PostgreSqlDatabaseProvider = "PostgreSql";
    public const string MSSqlDatabaseProvider = "MicrosoftSQLServer";
    #endregion

    #region task manager
    public const string TaskManagerSchemaName = "tasks";
    public const string TaskManagerTableName = "task_manager";
    public const string SummaryTaskTableName = "summary_task";
    public const string SubtaskTableName = "subtask";
    public const string TaskManagerCategoryTableName = "task_manager_category";
    #endregion

    public const string SqlConnectionSectionName = "SqlConnectionStrings";
    public const string PostgreSqlConnectionSectionName = "PostgreSqlConnectionStrings";
}
