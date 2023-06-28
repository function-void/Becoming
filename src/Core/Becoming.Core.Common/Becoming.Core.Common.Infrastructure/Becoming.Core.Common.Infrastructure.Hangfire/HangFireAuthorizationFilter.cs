using Hangfire.Dashboard;
using System.Diagnostics.CodeAnalysis;

namespace Becoming.Core.Common.Infrastructure.Hangfire;

public class HangFireAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize([NotNull] DashboardContext context)
    {
        return true;
    }
}