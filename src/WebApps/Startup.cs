using AspnetRunBasics.Services;
using AspnetRunBasics.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace AspnetRunBasics
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
            #region project services

            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<ICatalogService, CatalogService>();
            services.AddScoped<IOrderService, OrderService>();

            #endregion

            #region .: HTTP Client Injection :.

            services.AddHttpClient<ICatalogService, CatalogService>(client =>
            {
                client.BaseAddress = new Uri($"{Configuration["ApiSettings:GatewayAddress"]}{Configuration["ApiSettings:CatalogUrl"]}");
            });

            services.AddHttpClient<IBasketService, BasketService>(client =>
            {
                client.BaseAddress = new Uri($"{Configuration["ApiSettings:GatewayAddress"]}{Configuration["ApiSettings:BasketUrl"]}");
            });

            services.AddHttpClient<IOrderService, OrderService>(client =>
            {
                client.BaseAddress = new Uri($"{Configuration["ApiSettings:GatewayAddress"]}{Configuration["ApiSettings:OrderingUrl"]}");
            });

            #endregion

            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
