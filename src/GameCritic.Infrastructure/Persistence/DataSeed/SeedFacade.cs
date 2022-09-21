using Microsoft.EntityFrameworkCore;

namespace GameCritic.Infrastructure.Persistence.DataSeed
{
    public class SeedFacade
    {
        public static async Task SeedData(GameCriticDbContext dbContext)
        {
            dbContext.Database.Migrate();

            await PublisherSeed.Seed(dbContext);
            await GameSeed.Seed(dbContext);
            await AwardSeed.Seed(dbContext);
            await GameAwardSeed.Seed(dbContext);
        }
    }
}
