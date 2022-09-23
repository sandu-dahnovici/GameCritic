﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GameCritic.Domain.Auth;
using GameCritic.Infrastructure.Persistence.Repositories;
using GameCritic.Application.Common.Interfaces.Repositories;
using Azure.Storage.Blobs;
using GameCritic.Application.Common.Interfaces.Services;
using GameCritic.Infrastructure.Services;

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

            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddSingleton(x => new BlobServiceClient(configuration.GetConnectionString("AzureConnection")));
            services.AddSingleton<IBlobService>(sp =>
                new BlobService(sp.GetService<BlobServiceClient>(), configuration.GetValue<string>("Container")));

            //services.AddTransient<IAuthenticationService, AuthenticationService>();
            //services.AddTransient<ITokenService, TokenService>();

            return services;
        }
    }
}
