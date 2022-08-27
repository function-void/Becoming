namespace Becoming.Core.Common.Presentation;

public static class ApiConfigureSettings
{
    public const string API_DEFAULT_ROUTE = "api/v{version:apiVersion}/[controller]";
    public const string API_DEFAULT_ROUTE_WITH_ACTION = "api/v{version:apiVersion}/[controller]/[action]";
    public const string API_ACTRUAL_VERSION = "1.0";
}
