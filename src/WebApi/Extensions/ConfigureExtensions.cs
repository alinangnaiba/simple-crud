using Core.Entities;
using Core.Repositories;
using Infrastructure;
using Infrastructure.Logger;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using WebApi.Services;

namespace WebApi.Extensions
{
    public static class ConfigureExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, ApplicationSettings settings)
        {
            services.AddTransient<ILoggerManager, LoggerManager>();

            services.AddDbContext<AppDbContext>(
                opt => opt.UseSqlite(settings.ConnectionStrings));
            services.AddTransient<IRepository<Employee>, Repository<Employee>>();
            services.AddTransient<IEmployeeService, EmployeeService>();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Employee API",
                    Description = "A simple CRUD API"
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);
            });
        }
    }
}
