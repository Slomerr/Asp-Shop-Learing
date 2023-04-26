using ActiviryLogger;
using Interfaces.ActivityLogger;
using Interfaces.ShoppingCart;
using Shed.CoreKit.WebApi;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddCorrelationToken();
services.AddCors();
services.AddTransient<IActivityLogger, ActivityLoggerImpl>();
services.AddTransient<HttpClient>();
services.AddWebApiEndpoints(new WebApiEndpoint<IShoppingCart>(new Uri("https://localhost:5002")));
services.AddHostedService<Scheduler>();
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

app.UseWebApiEndpoint<IActivityLogger>();

app.Run();