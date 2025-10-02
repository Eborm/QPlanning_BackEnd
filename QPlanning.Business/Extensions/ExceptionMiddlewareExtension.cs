using Microsoft.AspNetCore.Builder;
using QPlanning.Business.Extensions.Middleware;

namespace QPlanning.Business.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseExceptionPersistance(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionPersistenceMiddleware>();
        }
    }
}