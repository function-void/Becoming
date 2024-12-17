using Microsoft.Extensions.DependencyInjection;
using Becoming.Core.Common.Application.Services;

namespace Becoming.Core.Common.Infrastructure.Services;

public static class ServiceConfigurationExtensions
{
    public static void AddSharedServicesInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
    }
}
