using MassTransit;
using Microservices.EventBus.Messages.Common;
using Microservices.Ordering.Application;
using Microservices.Ordering.Consumer.Consumers;
using Microservices.Ordering.Consumer.Mappings;
using Microservices.Ordering.Infraestructure;
using Microservices.Ordering.Infraestructure.Persistence;

Microsoft.Extensions.Hosting.IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddInfraestructure(hostContext.Configuration);
        services.AddApplicationServicesDependencyInjection();
        services.AddScoped<BasketCheckoutConsumer>();
        services.AddMassTransit(config =>
        {
            config.UsingRabbitMq((context, config) =>
            {
                config.Host(hostContext.Configuration.GetConnectionString("RabbitMq"));

                // configura a "fila"
                config.ReceiveEndpoint(EventBusConstants.BasketCheckoutQueue, configure =>
                {
                    configure.ConfigureConsumer<BasketCheckoutConsumer>(context);
                });
            });

            config.AddConsumer<BasketCheckoutConsumer>();
        });
        services.AddMassTransitHostedService();
        services.AddAutoMapper(typeof(OrderingProfile));
    })
    .Build();

await host.RunAsync();
