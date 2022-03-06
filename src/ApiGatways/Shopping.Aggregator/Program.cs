using Shopping.Aggregator.Services;
using Shopping.Aggregator.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<ICatalogService, CatalogService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:CatalogUrl"]);
});
builder.Services.AddHttpClient<IBasketService, BasketService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:BasketUrl"]);
});
builder.Services.AddHttpClient<IOrderService, OrderService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:OrderingUrl"]);
});
builder.Services.AddScoped<IShoppingService, ShoppingService>();


var app = builder.Build();

    
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
