using GameCritic.Domain.Entities;

namespace GameCritic.Infrastructure.Persistence.DataSeed
{
    public static class GenreSeed
    {
        public static async Task Seed(GameCriticDbContext dbContext)
        {
            if (dbContext.Genres.Any()) return;

            List<Genre> genres = new()
            {
                new()
                {
                    Name = "RPG",
                    Description = "A role-playing game (RPG) is a game in which each participant assumes the role of a character, generally in a fantasy or science fiction setting, that can interact within the game's imaginary world.",
                },
                new()
                {
                    Name = "Action-Adventure",
                    Description = "The action-adventure genre is a video game genre that combines core elements from both the action game and adventure game genres.Action-adventure is a hybrid genre and can include many games which might better be categorized under more narrow genres. Typically, pure adventure games have situational problems for the player to solve, with very little or no action.If there is action, it is generally confined to isolated minigames.Pure action games have gameplay based on real - time interactions that challenge the reflexes.Therefore, action - adventure games engage both reflexes and problem - solving in both violent and non - violent situations."
                },
                new()
                {
                    Name = "Open-world",
                    Description = "An open world is a level or game designed as nonlinear, open areas with many ways to reach an objective. Some games are designed with both traditional and open-world levels. An open world facilitates greater exploration than a series of smaller levels, or a level with more linear challenges."
                },
                new()
                {
                    Name = "Sport",
                    Description = "A sports video game is a video game that simulates the practice of sports. Most sports have been recreated with a game, including team sports, track and field, extreme sports, and combat sports."
                },
                new()
                {
                    Name = "Shooter",
                    Description = "Shooter video games or shooters are a subgenre of action video games where the focus is almost entirely on the defeat of the character's enemies using the weapons given to the player. Usually these weapons are firearms or some other long-range weapons, and can be used in combination with other tools such as grenades for indirect offense, armor for additional defense, or accessories such as telescopic sights to modify the behavior of the weapons."
                },
                new()
                {
                    Name = "First-person",
                    Description = "In video games, first person is any graphical perspective rendered from the viewpoint of the player's character, or a viewpoint from the cockpit or front seat of a vehicle driven by the character. The most popular type of first-person video game today is the first-person shooter (FPS), in which the graphical perspective is an integral component of the gameplay."
                },
                new()
                {
                    Name = "Fighting",
                    Description = "A fighting game, also known as a versus fighting game, is a genre of video game that involves combat between two or more players. Fighting game combat often features mechanics such as blocking, grappling, counter-attacking, and chaining attacks together into \"combos\"."
                },
                new()
                {
                    Name = "Historical",
                    Description = "The historical video games is a video game genre in which stories are based upon historical events, environments, or people. Some historical video games are simulators, which attempt an accurate portrayal of a historical event, civilization or biography, to the degree that the available historical research will allow."
                },
                new()
                {
                    Name = "Platformer",
                    Description = "A platform game, or platformer, is a genre of video game. Platformer gameplay is about jumping between platforms or over obstacles. The player controls these jumps and must use skill to avoid their character falling off of platforms or missing jumps. This kind of gameplay, even in other genres, is called \"platforming\"."
                },
                new()
                {
                    Name = "Racing",
                    Description = "Racing games are a video game genre in which the player participates in a racing competition with any type of land, water, air, or space vehicles. They may be based on anything from real-world racing leagues to fantastical settings."
                },
                new()
                {
                    Name = "Simulation",
                    Description = "Simulation games are a genre of games that are designed to mimic activities you'd see in the real world. The purpose of the game may be to teach you something. For example, you could learn how to fish. Others simulation games take on operating a business such as a farm or a theme park."
                },
                new()
                {
                    Name = "Action",
                    Description = "An action game is a video game genre that emphasizes physical challenges, including hand–eye coordination and reaction-time. The genre includes a large variety of sub-genres, such as fighting games, beat 'em ups, shooter games, and platform games."
                },
            };

            dbContext.AddRange(genres);
            await dbContext.SaveChangesAsync();
        }
    }
}
