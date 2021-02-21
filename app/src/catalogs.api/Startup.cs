using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using catalogs.api.Settings;
using catalogs.api.Data;
using catalogs.api.Data.Interfaces;
using catalogs.api.Repositories.Interfaces;
using catalogs.api.Repositories;

namespace catalogs.api
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "catalogs.api", Version = "v1" });
            });

            // Injetando a classe Catalog
            services.Configure<CatalogDatabaseSettings>(
                Configuration.GetSection(nameof(CatalogDatabaseSettings))
            );

            // Cadastrando nossa interface
            // Basicamente ele entende que toda classe que herdar a interface, deverá executar o seguinte comando
            // Como é um singleton, apenas a única instância executará o código
            services.AddSingleton<ICatalogDatabaseSettings, CatalogDatabaseSettings>();

            services.AddTransient<ICatalogContext,CatalogContext>();
            services.AddTransient<IProductRepository, ProductRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "catalogs.api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
