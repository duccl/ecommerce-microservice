using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((hostContext, logging) =>
{
    logging.ReadFrom.Configuration(hostContext.Configuration);
});
builder.Host.ConfigureAppConfiguration((hostContext, config) =>
{
    config.AddJsonFile($"Config/ocelot.{hostContext.HostingEnvironment.EnvironmentName}.json", reloadOnChange: true, optional: false);
});
builder.Logging.ClearProviders();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddOcelot()
    .AddCacheManager(settings => settings.WithDictionaryHandle());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.UseOcelot();

app.Run();