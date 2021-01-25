using Microsoft.AspNetCore.Builder;

namespace Delivery.WebAPI
{
    public static class ExceptionHandlingExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}