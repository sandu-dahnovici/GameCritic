using GameCritic.Domain.Entities;

namespace GameCritic.Infrastructure.Persistence.DataSeed
{
    public static class GameAwardSeed
    {
        public static async Task Seed(GameCriticDbContext dbContext)
        {
            if (dbContext.GameAwards.Any()) return;

            List<GameAward> gameAwards = new()
            {
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Grand Theft Auto V"),
                    Award = dbContext.Awards.First(a => a.Title == "Best Game of All Time"),
                    Rank = 1
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "The Witcher 3: Wild Hunt"),
                    Award = dbContext.Awards.First(a => a.Title == "Best Game of All Time"),
                    Rank = 2
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Red Dead Redemption 2"),
                    Award = dbContext.Awards.First(a => a.Title == "Best Game of All Time"),
                    Rank = 3
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Call Of Duty 4: Modern Warfare"),
                    Award = dbContext.Awards.First(a => a.Title == "Best Game of All Time"),
                    Rank = 4
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Unity"),
                    Award = dbContext.Awards.First(a => a.Title == "Best Game of All Time"),
                    Rank = 5
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Grand Theft Auto: San Andreas"),
                    Award = dbContext.Awards.First(a => a.Title == "Most Discussed Game of All Time"),
                    Rank = 1
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "The Witcher 3: Wild Hunt"),
                    Award = dbContext.Awards.First(a => a.Title == "Most Discussed Game of All Time"),
                    Rank = 2
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Grand Theft Auto V"),
                    Award = dbContext.Awards.First(a => a.Title == "Most Discussed Game of All Time"),
                    Rank = 3
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Red Dead Redemption 2"),
                    Award = dbContext.Awards.First(a => a.Title == "Most Discussed Game of All Time"),
                    Rank = 4
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Tom Clancy's SPLINTER CELL"),
                    Award = dbContext.Awards.First(a => a.Title == "Most Discussed Game of All Time"),
                    Rank = 5
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "The Witcher 3: Wild Hunt"),
                    Award = dbContext.Awards.First(a => a.Title == "Best RPG Game of All Time"),
                    Rank = 1
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Valhalla"),
                    Award = dbContext.Awards.First(a => a.Title == "Best RPG Game of All Time"),
                    Rank = 2
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "CYBERPUNK 2077"),
                    Award = dbContext.Awards.First(a => a.Title == "Best Game" && a.Year == 2020),
                    Rank = 1
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Valhalla"),
                    Award = dbContext.Awards.First(a => a.Title == "Best Game" && a.Year == 2020),
                    Rank = 2
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Watch Dogs: Legion"),
                    Award = dbContext.Awards.First(a => a.Title == "Best Game" && a.Year == 2020),
                    Rank = 3
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Call Of Duty: Black Ops 4"),
                    Award = dbContext.Awards.First(a => a.Title == "Most Discussed Game" && a.Year == 2018),
                    Rank = 1
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Unity"),
                    Award = dbContext.Awards.First(a => a.Title == "Most Discussed Game" && a.Year == 2014),
                    Rank = 1
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Call Of Duty: Black Ops III"),
                    Award = dbContext.Awards.First(a => a.Title == "Most shared Game" && a.Year == 2015),
                    Rank = 3
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Syndicate"),
                    Award = dbContext.Awards.First(a => a.Title == "Most shared Game" && a.Year == 2015),
                    Rank = 2 
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "The Witcher 3: Wild Hunt"),
                    Award = dbContext.Awards.First(a => a.Title == "Most shared Game" && a.Year == 2015),
                    Rank = 1
                },
            };

            dbContext.AddRange(gameAwards);
            await dbContext.SaveChangesAsync();
        }
    }
}
