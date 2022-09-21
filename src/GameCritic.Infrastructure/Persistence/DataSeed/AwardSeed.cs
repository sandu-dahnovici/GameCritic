using GameCritic.Domain.Entities;

namespace GameCritic.Infrastructure.Persistence.DataSeed
{
    public static class AwardSeed
    {
        public static async Task Seed(GameCriticDbContext dbContext)
        {
            if (dbContext.Awards.Any()) return;

            List<Award> awards = new()
            {
                new()
                {
                    Title = "Best Game of All Time",
                    Year = null,
                },
                new()
                {
                    Title = "Most Discussed Game",
                    Year = 2018,
                },
                new()
                {
                    Title = "Most Discussed Game of All Time",
                    Year = null,
                },
                new()
                {
                    Title = "Best Open-World Game of All Time",
                    Year = null,
                },
                new()
                {
                    Title = "Most Shared Game of All Time",
                    Year = null,
                },
                new()
                {
                    Title = "Best Game",
                    Year = 2020,
                },
                new()
                {
                    Title = "Most Discussed Game",
                    Year = 2014,
                },
                new()
                {
                    Title = "Most shared Game",
                    Year = 2015,
                },
                new()
                {
                    Title = "Best RPG Game of All Time",
                    Year = null
                }
            };

            dbContext.AddRange(awards);
            await dbContext.SaveChangesAsync();
        }
    }
}
