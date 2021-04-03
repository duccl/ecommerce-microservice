using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
namespace Settings.Database
{
    public static class DatabaseServiceExtension
    {
        public static IServiceCollection AddDatabaseBinding<TInterface, TClass>( this IServiceCollection services, 
                                                              IConfiguration configuration) where TClass: new()
        {
            var settingsObject = new TClass();
            var section =configuration.GetSection(typeof(TClass).Name); 
            section.Bind(settingsObject);
            services.AddSingleton(typeof(TInterface),settingsObject);
            return services;
        }

        public static IServiceCollection AddDatabaseBinding<TClass>(IServiceCollection services, 
                                                              IConfiguration configuration) where TClass: new()
        {
            var settingsObject = new TClass();
            var section =configuration.GetSection(typeof(TClass).Name); 
            section.Bind(settingsObject);
            services.AddSingleton(typeof(TClass));
            return services;
        }
    }
}
