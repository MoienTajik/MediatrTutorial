using MediatrTutorial.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace MediatrTutorial
{
    public static class StartupExtensions
    {
        public static void UseErrorHandling(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}