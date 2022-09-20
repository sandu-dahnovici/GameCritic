using GameCritic.Domain.Entities;

namespace GameCritic.Infrastructure.Persistence.DataSeed
{
    public static class PublisherSeed
    {
        public static async Task Seed(GameCriticDbContext dbContext)
        {
            if (dbContext.Publishers.Any()) return;

            List<Publisher> publishers = new()
            {
                new()
                {
                    Name = "Ubisoft",
                    Country = "France",
                    FoundationYear = 1986,
                    WebsiteURL = "https://www.ubisoft.com/",
                    NumberOfEmployees = 21000,
                },
                new()
                {
                    Name = "Rockstar Games",
                    Country = "US",
                    FoundationYear = 1998,
                    WebsiteURL = "https://www.rockstargames.com/",
                    NumberOfEmployees = 2200,
                },
                new()
                {
                    Name = "Electronic Arts",
                    Country = "US",
                    FoundationYear = 1982,
                    WebsiteURL = "https://www.ea.com/",
                    NumberOfEmployees = 12900
                },
                new()
                {
                    Name = "Valve Corporation",
                    Country = "US",
                    FoundationYear = 1996,
                    WebsiteURL = "https://www.valvesoftware.com/",
                    NumberOfEmployees = 360,
                },
                new()
                {
                    Name = "Activision Blizzard",
                    Country = "US",
                    FoundationYear = 1979,
                    WebsiteURL = "https://www.activisionblizzard.com/",
                    NumberOfEmployees = 9800
                },
                new()
                {
                    Name = "CD PROJEKT RED",
                    Country = "Poland",
                    FoundationYear = 1994,
                    WebsiteURL = "https://cdprojektred.com",
                    NumberOfEmployees = 350
                },
                new()
                {
                    Name = "Warner Bros. Interactive Entertainment",
                    Country = "US",
                    FoundationYear = 2004,
                    WebsiteURL = "https://warnerbrosgames.com/",
                    NumberOfEmployees = 1780
                }
            };

            dbContext.AddRange(publishers);
            await dbContext.SaveChangesAsync();
        }
    }
}
