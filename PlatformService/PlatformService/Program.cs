using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PlatformService.AsyncDataServices;
using PlatformService.Data;
using PlatformService.SyncDataServices.Http;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;
var env = builder.Environment;

if (env.IsProduction())
{
    Console.WriteLine("--> Using SqlServier Db");
    services.AddDbContext<AppDbContext>(options => 
    {
        options.UseSqlServer(configuration.GetConnectionString("PlatformsConnection"));
    });
}
else
{
    Console.WriteLine("--> Using InMem Db");
    services.AddDbContext<AppDbContext>(options =>
    {
        options.UseInMemoryDatabase("InMem");
    });
}

services.AddScoped<IPlatformRepository, PlatformRepository>();
services.AddSingleton<IMessageBusClient, MessageBusClient>();

services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();

services.AddControllers();
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo{Title = "PlatformService", Version = "1.0.0"});
});

Console.WriteLine($"--> CommandService Endpoint {configuration["CommandService"]}");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

PrepDb.PrepPopulation(app, env.IsProduction());

//app.MapGet("/", () => "hello world");
app.Run();

