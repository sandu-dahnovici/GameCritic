using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GameCritic.Domain.Auth;
using GameCritic.Infrastructure.Persistence.Repositories;
using GameCritic.Application.Common.Interfaces.Repositories;
using Azure.Storage.Blobs;
using GameCritic.Application.Common.Interfaces.Services;
using GameCritic.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using GameCritic.Infrastructure.Options;

namespace GameCritic.Infrastructure.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GameCriticDbContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(configuration.GetConnectionString("GameCriticConnection"),
                providerOptions => providerOptions.EnableRetryOnFailure());
            });

            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 0;
                options.User.AllowedUserNameCharacters =  "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@._";
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<GameCriticDbContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<IUnitOfWork,UnitOfWork>();

            services.AddSingleton(serviceProvider => new BlobServiceClient(configuration.GetConnectionString("AzureConnection")));
            services.AddSingleton<IBlobService>(serviceProvider =>
                new BlobService(serviceProvider.GetService<BlobServiceClient>(), configuration.GetValue<string>("Container")));

            services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));
            services.AddTransient<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
