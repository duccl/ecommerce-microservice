using Microservices.Ordering.Application.Contracts.Infraestructure;
using Microservices.Ordering.Application.Contracts.Persistence;
using Microservices.Ordering.Domain.Entities;
using Microservices.Ordering.Infraestructure.Mail;
using Microservices.Ordering.Infraestructure.Persistence;
using Microservices.Ordering.Infraestructure.Repositories;
using Microservices.Ordering.Infraestructure.Repositories.Base;
using Microservices.Ordering.Infraestructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Microservices.Ordering.Infraestructure
{
    public static class InfraestructureDependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddInfraestructureServices()
                .AddInfraestructurePersistence(configuration)
                .AddInfraestructureRepositories()
                .ConfigureInfraestructureSettings(configuration);
        }

        private static IServiceCollection AddInfraestructureServices(this IServiceCollection services)
        {
            services.AddTransient<IEmailService, EmailService>();
            return services;
        }
        private static IServiceCollection AddInfraestructurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContextBase>(
                options => options.UseSqlServer(configuration.GetConnectionString("SqlServer"))
            );

            return services;
        }
        private static IServiceCollection AddInfraestructureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IAsyncRepository<Order>, RepositoryBase<Order>>();
            return services;
        }
        private static IServiceCollection ConfigureInfraestructureSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<IOptions<EmailSettings>>(c => configuration.GetSection("EmailSettings"));
            return services;
        }
    }
}
