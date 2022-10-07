using GameCritic.API.Middlewares;

namespace GameCritic.API.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app) => app.UseMiddleware<ExceptionHandlingMiddleware>();

        public static IApplicationBuilder UseDbTransaction(this IApplicationBuilder app) => app.UseMiddleware<DbTransactionMiddleware>();

        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder app) => app.UseMiddleware<RequestLoggingMiddleware>();
    }
}