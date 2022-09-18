using Microsoft.OpenApi.Models;
using GameCritic.Infrastructure.Persistence.Extensions;
using GameCritic.Application.Extensions;

namespace GameCritic.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddApplication();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }
    }
}
