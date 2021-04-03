using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using catalogs.api.Settings;
using catalogs.api.Data;
using catalogs.api.Data.Interfaces;
using catalogs.api.Repositories.Interfaces;
using catalogs.api.Repositories;
using Microsoft.Extensions.Logging;
using Settings.Database;

namespace catalogs.api
{
    public class Startup
    {
        public ILogger<Startup> _logger;
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "catalogs.api", Version = "v1" });
            });

            // Cadastrando nossa interface
            // Basicamente ele entende que toda classe que herdar a interface, devera executar o seguinte comando
            // Como eh um singleton, apenas a unica instancia executara o codigo
            services.AddDatabaseBinding<ICatalogDatabaseSettings, CatalogDatabaseSettings>(Configuration);

            services.AddTransient<ICatalogContext,CatalogContext>();
            services.AddTransient<IProductRepository, ProductRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            _logger = logger;
            _logger.LogInformation($"Up and running with env with development as {env.IsDevelopment()}");
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
