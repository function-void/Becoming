using Becoming.Core.Common.Abstractions.Contracts;
using Becoming.Core.Common.Infrastructure.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Becoming.Core.Common.Infrastructure.Services
{
    public static class ServiceConfigurationExtensions
    {
        public static void AddSharedServicesInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        }
    }
}
