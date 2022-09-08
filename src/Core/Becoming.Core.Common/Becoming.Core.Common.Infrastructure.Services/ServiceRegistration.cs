using Becoming.Core.Common.Abstractions.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Becoming.Core.Common.Infrastructure.Services
{
    public static class ServiceRegistration
    {
        public static void AddServicesInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        }
    }
}
