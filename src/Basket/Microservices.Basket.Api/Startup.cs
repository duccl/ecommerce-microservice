using Microservices.Basket.Application.Services;
using Microservices.Basket.Data.Repositories;
using Microservices.Basket.Domain.Interfaces.Repositories;
using Microservices.Basket.Domain.Interfaces.Services;
using Microservices.Discount.Grpc.Protos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using MassTransit;
using Microservices.Basket.Application.Mappings;

namespace Microservices.Basket.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(
                options => options.Address = new Uri(Configuration.GetValue<string>("GrpcSettings:DiscountUrl"))
             );
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Microservices.Basket.Api", Version = "v1" });
            });

            services.AddStackExchangeRedisCache(options =>
            {
                Configuration.GetSection(options.GetType().Name).Bind(options);
            });

            services.AddMassTransit(config =>
            {
                config.UsingRabbitMq((context, config) =>
                {
                    config.Host(Configuration.GetConnectionString("RabbitMq"));
                });
            });
            services.AddMassTransitHostedService();

            services.AddAutoMapper(typeof(ApplicationMappingProfile));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Microservices.Basket.Api v1"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
