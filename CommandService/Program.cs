using CommandService.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("InMem");
});
services.AddScoped<ICommandRepository, CommandRepository>();
services.AddControllers();
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
