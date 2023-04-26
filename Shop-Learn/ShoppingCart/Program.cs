using Interfaces.ProductCatalog;
using Interfaces.ShoppingCart;
using Shed.CoreKit.WebApi;
using ShoppingCart;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddCorrelationToken();
services.AddCors();
services.AddTransient<IShoppingCart, ShoppingCartImpl>();
services.AddTransient<HttpClient>();
services.AddWebApiEndpoints(new WebApiEndpoint<IProductCatalog>(new Uri("https://localhost:5001")));
services.AddLogging(builder => builder.AddConsole());
//TODO: services.AddRequestLoggins();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCorrelationToken();
//app.UseRequestLogging("getevents");
app.UseCors(builder =>
{
    builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
});

app.UseWebApiEndpoint<IShoppingCart>();

app.Run();