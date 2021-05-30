using Microservices.Settings.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Settings.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoDatabaseSettingsBind(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDatabaseOptions>(configuration.GetSection(MongoDatabaseOptions.MongoDatabaseSection));
            return services;
        }
    }
}
