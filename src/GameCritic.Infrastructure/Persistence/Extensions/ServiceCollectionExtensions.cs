using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GameCritic.Domain.Auth;
using GameCritic.Infrastructure.Persistence.Repositories;
using GameCritic.Application.Common.Interfaces;

namespace GameCritic.Infrastructure.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GameCriticDbContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(configuration.GetConnectionString("GameCriticConnection"));
            });

            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 8;
            })
            .AddEntityFrameworkStores<GameCriticDbContext>();


            services.AddScoped<IUnitOfWork,UnitOfWork>();
            //services.AddTransient<IAuthenticationService, AuthenticationService>();
            //services.AddTransient<ITokenService, TokenService>();

            return services;
        }
    }
}
