using GameCritic.Domain.Entities;

namespace GameCritic.Infrastructure.Persistence.DataSeed
{
    public static class GameGenreSeed
    {
        public static async Task Seed(GameCriticDbContext dbContext)
        {
            if (dbContext.GameGenres.Any()) return;

            List<GameGenre> gameGenres = new()
            {
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Grand Theft Auto V"),
                    Genre = dbContext.Genres.First(g => g.Name == "Action-Adventure"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Grand Theft Auto V"),
                    Genre = dbContext.Genres.First(g => g.Name == "Open-world"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Half-life 2"),
                    Genre = dbContext.Genres.First(g => g.Name == "First-person"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Half-life 2"),
                    Genre = dbContext.Genres.First(g => g.Name == "Shooter"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "The Witcher 3: Wild Hunt"),
                    Genre = dbContext.Genres.First(g => g.Name == "RPG"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "The Witcher 3: Wild Hunt"),
                    Genre = dbContext.Genres.First(g => g.Name == "Open-world"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Red Dead Redemption 2"),
                    Genre = dbContext.Genres.First(g => g.Name == "Action-Adventure"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Red Dead Redemption 2"),
                    Genre = dbContext.Genres.First(g => g.Name == "Open-world"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Call Of Duty 4: Modern Warfare"),
                    Genre = dbContext.Genres.First(g => g.Name == "Shooter"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Call Of Duty 4: Modern Warfare"),
                    Genre = dbContext.Genres.First(g => g.Name == "First-person"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Team Fortress 2"),
                    Genre = dbContext.Genres.First(g => g.Name == "Shooter"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Team Fortress 2"),
                    Genre = dbContext.Genres.First(g => g.Name == "First-person"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Team Fortress 2"),
                    Genre = dbContext.Genres.First(g => g.Name == "Action"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "CYBERPUNK 2077"),
                    Genre = dbContext.Genres.First(g => g.Name == "RPG"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "CYBERPUNK 2077"),
                    Genre = dbContext.Genres.First(g => g.Name == "Action"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Mortal Kombat 11"),
                    Genre = dbContext.Genres.First(g => g.Name == "Fighting"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Valhalla"),
                    Genre = dbContext.Genres.First(g => g.Name == "RPG"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Valhalla"),
                    Genre = dbContext.Genres.First(g => g.Name == "Action-Adventure"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Valhalla"),
                    Genre = dbContext.Genres.First(g => g.Name == "Open-world"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Valhalla"),
                    Genre = dbContext.Genres.First(g => g.Name == "Historical"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Watch Dogs: Legion"),
                    Genre = dbContext.Genres.First(g => g.Name == "Action-Adventure"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Watch Dogs: Legion"),
                    Genre = dbContext.Genres.First(g => g.Name == "Open-world"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Call Of Duty: Black Ops 4"),
                    Genre = dbContext.Genres.First(g => g.Name == "Shooter"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Call Of Duty: Black Ops 4"),
                    Genre = dbContext.Genres.First(g => g.Name == "First-person"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Call Of Duty: Black Ops 4"),
                    Genre = dbContext.Genres.First(g => g.Name == "Action"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Call Of Duty: Black Ops III"),
                    Genre = dbContext.Genres.First(g => g.Name == "Shooter"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Call Of Duty: Black Ops III"),
                    Genre = dbContext.Genres.First(g => g.Name == "First-person"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Call Of Duty: Black Ops III"),
                    Genre = dbContext.Genres.First(g => g.Name == "Action"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Syndicate"),
                    Genre = dbContext.Genres.First(g => g.Name == "Open-world"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Syndicate"),
                    Genre = dbContext.Genres.First(g => g.Name == "Historical"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Unity"),
                    Genre = dbContext.Genres.First(g => g.Name == "Open-world"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Unity"),
                    Genre = dbContext.Genres.First(g => g.Name == "Historical"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Unity"),
                    Genre = dbContext.Genres.First(g => g.Name == "Action"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "FIFA 18"),
                    Genre = dbContext.Genres.First(g => g.Name == "Sport"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "F1 22"),
                    Genre = dbContext.Genres.First(g => g.Name == "Racing"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Grand Theft Auto: San Andreas"),
                    Genre = dbContext.Genres.First(g => g.Name == "Open-world"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Grand Theft Auto: San Andreas"),
                    Genre = dbContext.Genres.First(g => g.Name == "Action-Adventure"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Tom Clancy's SPLINTER CELL"),
                    Genre = dbContext.Genres.First(g => g.Name == "Open-world"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Tom Clancy's SPLINTER CELL"),
                    Genre = dbContext.Genres.First(g => g.Name == "Action-Adventure"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Tom Clancy's SPLINTER CELL"),
                    Genre = dbContext.Genres.First(g => g.Name == "Simulation"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "CUPHEAD"),
                    Genre = dbContext.Genres.First(g => g.Name == "Platformer"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Watch Dogs 2"),
                    Genre = dbContext.Genres.First(g => g.Name == "Action-Adventure"),
                },
                new()
                {
                    Game = dbContext.Games.First(g => g.Title == "Watch Dogs 2"),
                    Genre = dbContext.Genres.First(g => g.Name == "Open-world"),
                },
            };

            dbContext.AddRange(gameGenres);
            await dbContext.SaveChangesAsync();
        }
    }
}
