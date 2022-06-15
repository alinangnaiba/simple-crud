using Infrastructure.Extensions;
using Microsoft.OpenApi.Models;
using System.Reflection;
using WebApi;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
var appsettings = builder.Configuration.GetSection("ApplicationSettings")
    .Get<ApplicationSettings>();

//logging
builder.Host.ConfigureLogging(logging => 
{
    logging.ClearProviders();
    logging.AddConsole();
});

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.ConfigureServices(appsettings);

builder.Services.AddControllers();
builder.Services.AddRouting(opts => opts.LowercaseUrls = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.ConfigureSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//use global exception handler
app.UseExceptionMiddleware();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
