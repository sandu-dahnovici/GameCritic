using Microsoft.AspNetCore.Identity;
using GameCritic.Domain.Auth;
using GameCritic.Infrastructure.Persistence;
using GameCritic.Infrastructure.Persistence.DataSeed;

namespace GameCritic.API.Extensions
{
    public static class HostExtensions
    {
        public static async Task SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<GameCriticDbContext>();
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    var roleManager = services.GetRequiredService<RoleManager<Role>>();

                    await SeedFacade.SeedData(context,userManager,roleManager);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured during migration");
                }
            }
        }
    }
}