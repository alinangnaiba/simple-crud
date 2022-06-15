using Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Infrastructure.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
