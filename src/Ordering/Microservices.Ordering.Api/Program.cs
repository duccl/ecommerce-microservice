using Hellang.Middleware.ProblemDetails;
using Microservices.Ordering.Api.Extensions;
using Microservices.Ordering.Application;
using Microservices.Ordering.Infraestructure;
using Microservices.Ordering.Infraestructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.ToString());
});
builder.Services.AddInfraestructure(builder.Configuration);
builder.Services.AddApplicationServicesDependencyInjection();
builder.Services.MigrateDataBase<ContextBase>((context, provider) =>
{
    var logger = provider.GetRequiredService<ILogger<OrderContextSeed>>();
    OrderContextSeed.SeedAsync(context, logger).Wait();
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();

app.MapControllers();

app.Run();
