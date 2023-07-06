namespace Becoming.Core.Common.Presentation.Tools;

public static class ApiConfigurationProvider
{
    public const string API_DEFAULT_ROUTE = "api/v{version:apiVersion}/[controller]";
    public const string API_DEFAULT_ROUTE_WITH_ACTION = "api/v{version:apiVersion}/[controller]/[action]";
    public const string API_ACTUAL_VERSION = "1.0";
}
