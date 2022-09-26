using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GameCritic.Domain.Auth;

namespace GameCritic.Infrastructure.Persistence.DataSeed
{
    public class SeedFacade
    {
        public static async Task SeedData(GameCriticDbContext dbContext,UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            dbContext.Database.Migrate();

            await PublisherSeed.Seed(dbContext);
            await GameSeed.Seed(dbContext);
            await AwardSeed.Seed(dbContext);
            await GameAwardSeed.Seed(dbContext);
            await GenreSeed.Seed(dbContext);
            await GameGenreSeed.Seed(dbContext);
            await RoleSeed.Seed(roleManager);
            await UserSeed.Seed(userManager);
            await ReviewSeed.Seed(dbContext, userManager);
        }
    }
}
