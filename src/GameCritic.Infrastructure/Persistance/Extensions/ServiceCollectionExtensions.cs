using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GameCritic.Domain.Auth;


namespace GameCritic.Infrastructure.Persistance.Extensions
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

            //services.AddScoped<IRepository, EFCoreRepository>();
            //services.AddTransient<IAuthenticationService, AuthenticationService>();
            //services.AddTransient<ITokenService, TokenService>();

            return services;
        }
    }
}
