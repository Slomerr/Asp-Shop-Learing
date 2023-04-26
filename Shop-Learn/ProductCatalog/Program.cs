using Interfaces;
using Interfaces.ProductCatalog;
using ProductCatalog;
using Shed.CoreKit.WebApi;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddCorrelationToken();
services.AddCors();
services.AddTransient<IProductCatalog, ProductCatalogImpl>();
services.AddLogging(builder => builder.AddConsole());
//services.AddRequestLogging();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCorrelationToken();
//app.UseRequestLogging();
app.UseCors(builder =>
{
    builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
});

app.UseWebApiEndpoint<IProductCatalog>();

app.Run();