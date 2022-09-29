using GameCritic.Infrastructure.Persistence;

namespace GameCritic.API.Middlewares
{
    public class DbTransactionMiddleware
    {
        private readonly RequestDelegate _next;

        public DbTransactionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext,GameCriticDbContext  dbContext)
        {
            // For HTTP GET opening transaction is not required
            if (httpContext.Request.Method == HttpMethod.Get.Method)
            {
                await _next(httpContext);
                return;
            }

            var strategy = dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync<object, object>(null!, operation: async (dbctx, state, cancel) =>
            {
                // start the transaction
                await using var transaction = await dbContext.Database.BeginTransactionAsync();

                // invoke next middleware 
                await _next(httpContext);

                // commit the transaction
                await transaction.CommitAsync();

                return null!;
            }, null);

        }



    }
}