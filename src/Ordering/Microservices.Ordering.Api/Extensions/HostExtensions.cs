using Microsoft.EntityFrameworkCore;
using Polly;

namespace Microservices.Ordering.Api.Extensions
{
    public static class HostExtensions
    {
        public static void MigrateDataBase<TContext>(this IServiceCollection services, Action<TContext, IServiceProvider> seeder, int retry = 0) where TContext: DbContext
        {
            var retryPolicy = Policy.Handle<Exception>().WaitAndRetry(retry, sleepTime => TimeSpan.FromSeconds(1));
            retryPolicy.Execute(() =>
            {
                using var provider = services.BuildServiceProvider();
                var logger = provider.GetRequiredService<ILogger<TContext>>();
                var context = provider.GetService<TContext>();

                if (context == default)
                    return;

                logger.LogInformation($"Start Migrating {typeof(TContext).Name}");

                context.Database.Migrate();
                seeder(context, provider);

                logger.LogInformation($"End Migrating {typeof(TContext).Name}");
            });
        }
    }
}
