using Interfaces.ActivityLogger;
using Interfaces.ProductCatalog;
using Interfaces.ShoppingCart;
using Shed.CoreKit.WebApi;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.Use(async (context, next) =>
{
    if (string.IsNullOrEmpty(context.Request.Path.Value.Trim('/')))
    {
        context.Request.Path = "/index.html";
    }

    await next();
});

app.UseStaticFiles();

app.UseWebApiRedirect("api/products", new WebApiEndpoint<IProductCatalog>(new Uri("https://localhost:5001")));
app.UseWebApiRedirect("api/orders", new WebApiEndpoint<IShoppingCart>(new Uri("https://localhost:5002")));
app.UseWebApiRedirect("api/logs", new WebApiEndpoint<IActivityLogger>(new Uri("https://localhost:5003")));

app.Run();