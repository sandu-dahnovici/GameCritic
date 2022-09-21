using GameCritic.Domain.Entities;

namespace GameCritic.Infrastructure.Persistence.DataSeed
{
    public static class GameSeed
    {
        public static async Task Seed(GameCriticDbContext dbContext)
        {
            if (dbContext.Games.Any()) return;

            List<Game> games = new()
            {
                new()
                {
                    Title = "Grand Theft Auto V",
                    ReleaseDate = new DateTime(2015,4,13),
                    Summary = "Los Santos: a sprawling sun-soaked metropolis full of self-help gurus, starlets and fading celebrities, once the envy of the Western world, now struggling to stay alive in a time of economic uncertainty and cheap reality TV. Amidst the turmoil, three very unique criminals plot their own chances of survival and success: Franklin, a street hustler looking for tangible opportunities and serious money; Michael, a professional ex-con whose retirement is less rosy than he figured it would be; and Trevor, a violent dude driven by the opportunity for a cheap high and his next big score. With options at a premium, the crew risks it all in a myriad of daring and dangerous heists that could set them up for life.",
                    Price = 30,
                    Playtime = 31.5,
                    Publisher = dbContext.Publishers.First(p => p.Name == "Rockstar Games"),
                },
                new()
                {
                    Title = "Half-life 2",
                    ReleaseDate = new DateTime(2004,11,16),
                    Summary = "By taking the suspense, challenge and visceral charge of the original, and adding startling new realism and responsiveness, Half-Life 2 opens the door to a world where the player's presence affects everything around him, from the physical environment to the behaviors -- even the emotions -- of both friends and enemies. The player again picks up the crowbar of research scientist Gordon Freeman, who finds himself on an alien-infested Earth being picked to the bone, its resources depleted, its populace dwindling. Freeman is thrust into the unenviable role of rescuing the world from the wrong he unleashed back at Black Mesa. And a lot of people -- people he cares about -- are counting on him.",
                    Price = 25,
                    Playtime = 13,
                    Publisher = dbContext.Publishers.First(p => p.Name == "Valve Corporation"),
                },
                new()
                {
                    Title = "The Witcher 3: Wild Hunt",
                    ReleaseDate = new DateTime(2015,5,18),
                    Summary = "With the Empire attacking the Kingdoms of the North and the Wild Hunt, a cavalcade of ghastly riders, breathing down your neck, the only way to survive is to fight back. As Geralt of Rivia, a master swordsman and monster hunter, leave none of your enemies standing. Explore a gigantic open world, slay beasts and decide the fates of whole communities with your actions, all in a genuine next generation format.",
                    Price = 27.5m,
                    Playtime = 51,
                    Publisher = dbContext.Publishers.First(p => p.Name == "CD PROJEKT RED"),
                },
                new()
                {
                    Title = "Red Dead Redemption 2",
                    ReleaseDate = new DateTime(2019,11,5),
                    Summary = "America, 1899. The end of the wild west era has begun as lawmen hunt down the last remaining outlaw gangs. Those who will not surrender or succumb are killed. After a robbery goes badly wrong in the western town of Blackwater, Arthur Morgan and the Van der Linde gang are forced to flee. With federal agents and the best bounty hunters in the nation massing on their heels, the gang must rob, steal and fight their way across the rugged heartland of America in order to survive. As deepening internal divisions threaten to tear the gang apart, Arthur must make a choice between his own ideals and loyalty to the gang who raised him. From the creators of Grand Theft Auto V and Red Dead Redemption, Red Dead Redemption 2 is an epic tale of life in America at the dawn of the modern age.",
                    Price = 35,
                    Playtime = 73.5,
                    Publisher = dbContext.Publishers.First(p => p.Name == "Rockstar Games"),
                },
                new()
                {
                    Title = "Call Of Duty 4: Modern Warfare",
                    ReleaseDate = new DateTime(2007,11,5),
                    Summary = "As Call of Duty 4: Modern Warfare's single player campaign unfolds, the player is introduced to new gameplay at every turn – one moment you are fast-roping from your Black Hawk helicopter after storming into the war zone with an armada of choppers, the next you are a sniper, under concealment, in a Ghillie suit miles behind enemy lines, the next you are engaging hostiles from an AC-130 gunship thousands of feet above the battlefield. Mixed with explosive action, Call of Duty 4: Modern Warfare also delivers special effects, including use of depth of field, rim-lighting, character self-shadowing, real time post-processing, texture streaming as well as physics-enabled effects. Infinity Ward deployed a dedicated team from the start to deliver a new level of depth to multiplayer. Building on the hit \"Call of Duty 2\" online experience, Call of Duty 4: Modern Warfare's new multiplayer provides the community an addictive and accessible experience to gamers of all levels.",
                    Price = 23,
                    Playtime = 7,
                    Publisher = dbContext.Publishers.First(p => p.Name == "Activision Blizzard"),
                },
                new()
                {
                    Title = "Team Fortress 2",
                    ReleaseDate = new DateTime(2007,10,10),
                    Summary = "Team Fortress 2 (TF2) is the sequel to the game that put class-based, multiplayer team warfare on the map. TF2 delivers new gametypes, a signature art style powered by Valve’s next generation animation technology, persistent player statistics, and more. Unlike other \"class-based\" games that offer a variety of combat classes only, Team Fortress 2 packs a wild variety of classes which provide a broad range of tactical abilities and personalities, and lend themselves to a variety of player skills. Play as the flame-throwing Pyro, the room clearing Heavy, or the Spy, a master of disguises. Other classes include: Scout, Sniper, Medic, Engineer, Demoman, or Soldier. TF2 features the most advanced graphics of any Source-based game released to date – and the most exciting class-based action ever created.",
                    Price = 25.5m,
                    Playtime = null,
                    Publisher = dbContext.Publishers.First(p => p.Name == "Valve Corporation"),
                },
                new()
                {
                    Title = "CYBERPUNK 2077",
                    ReleaseDate = new DateTime(2020,12,10),
                    Summary = "Cyberpunk 2077 is an open-world, action-adventure story set in Night City, a megalopolis obsessed with power, glamour and body modification. Assume the role of V, a mercenary outlaw going after a one-of-a-kind implant that is the key to immortality. You can customize your character’s cyberware, skillset and playstyle, and explore a vast city where the choices you make shape the story and the world around you. Become a cyberpunk, an urban mercenary equipped with cybernetic enhancements and build your legend on the streets of Night City. Take the riskiest job of your life and go after a prototype implant that is the key to immortality.",
                    Price = 28.5m,
                    Playtime = 23.5,
                    Publisher = dbContext.Publishers.First(p => p.Name == "CD PROJEKT RED")
                },
                new()
                {
                    Title = "Mortal Kombat 11",
                    ReleaseDate = new DateTime(2019,4,23),
                    Summary = "Mortal Kombat is back and better than ever in the next evolution of the iconic franchise. The all new Custom Character Variations give you unprecedented control to customize the fighters and make them your own. The new graphics engine showcasing every skull-shattering, eye-popping moment, brings you so close to the fight you can feel it. And featuring a roster of new and returning Klassic Fighters, Mortal Kombat's best in class cinematic story mode continues the epic saga over 25 years in the making.",
                    Price = 34,
                    Publisher = dbContext.Publishers.First(p => p.Name == "Warner Bros. Interactive Entertainment")
                },
                new()
                {
                    Title = "Assassin's Creed Valhalla",
                    ReleaseDate = new DateTime(2020,11,10),
                    Summary = "Build your own Viking Legend. Become Eivor, a Viking raider raised to be a fearless warrior, and lead your clan from icy desolation in Norway to a new home amid the lush farmlands of ninth-century England. Find your settlement and conquer this hostile land by any means to earn a place in Valhalla. England in the age of the Vikings is a fractured nation of petty lords and warring kingdoms. Beneath the chaos lies a rich and untamed land waiting for a new conqueror. Will it be you? Write Your Viking Saga. Blaze your own path across England with advanced RPG mechanics. Fight brutal battles, lead fiery raids or use strategy and alliances with other leaders to bring victory. Every choice you make in combat and conversation is another step on the path to greatness. Lead Epic Raids. Lead a crew of raiders and launch lightning-fast surprise attacks against Saxon armies and fortresses. Unleash the ruthless fighting style of a Viking warrior as you dual-wield axes, swords, or even shields against relentless foes. Decapitate opponents in close-quarters combat, riddle them with arrows, or assassinate them with your Hidden Blade. Grow Your Settlement. Your clan's new home grows with your legend. Customise your settlement by building upgradable structures. Unlock new features and quests by constructing a barracks, a blacksmith, a tattoo parlour, and much more. Share Your Custom Raider. Recruit mercenary Vikings designed by other players or create and customise your own to share online. Sit back and reap the rewards when they fight alongside your friends in their game worlds. A Dark Age Open World. Sail across the icy North Sea to discover and conquer the broken kingdoms of England. Immerse yourself in activities like hunting and drinking games or engage in traditional Norse competitions like flyting – or, as it's better known, verbally devastating rivals through the art of the Viking rap battle.",
                    Price = 40,
                    Playtime = 60,
                    Publisher = dbContext.Publishers.First(p => p.Name == "Ubisoft"),
                },
                new()
                {
                    Title = "Watch Dogs: Legion",
                    ReleaseDate = new DateTime(2020,7,3),
                    Summary = "In the near future, London is facing its downfall: the people are being oppressed by an all-seeing surveillance state, a corrupt private military corporation controls the streets, and a powerful crime syndicate is preying on the vulnerable. The fate of London lies with you, and your ability to recruit a resistance and fight back. Watch Dogs: Legion delivers a never-before - seen gameplay innovation that allows you to recruit and play as anyone you see in the iconic city of London.Every single character in the open world is playable, and everyone has a backstory, personality, and skillset that will help you personalize your own unique team.Bring your characters online and join forces with friends to take back London in four - player co - op missions, end - game challenges, and daily events.Welcome to the Resistance.",
                    Price = 38,
                    Playtime = 28,
                    Publisher = dbContext.Publishers.First(p => p.Name == "Ubisoft")
                },
                new()
                {
                    Title = "Call Of Duty: Black Ops 4",
                    ReleaseDate = new DateTime(2018,10,12),
                    Summary = "Black Ops returns - in your face. Featuring gritty, grounded, fluid Multiplayer combat, a massive Zombies offering with 3 full undead adventures at launch, and Blackout, where the universe of Black Ops comes to life in one huge battle royale experience featuring the largest map in Call of Duty history, signature Black Ops combat, characters, locations and weapons from the entire Black Ops series. Soldier up for all-out combat – tailor made for the Black Ops community.",
                    Price = 32,
                    Playtime = 12,
                    Publisher = dbContext.Publishers.First(p => p.Name == "Activision Blizzard")
                },
                new()
                {
                    Title = "Call Of Duty: Black Ops III",
                    ReleaseDate = new DateTime(2015,11,6),
                    Summary = "In Black Ops 3, Treyarch introduces a new momentum-based chained-movement system which enables players to fluidly move through the environment with finesse, using controlled thrust jumps, slides, wall runs and mantling abilities in a myriad of combinations, all while continuously keeping full control over their weapon. Maps are designed from the ground-up for the new movement system, enabling players to be successful with traditional movement, as well as with advanced tactics and maneuvers.",
                    Price = 21.5m,
                    Playtime = 15,
                    Publisher = dbContext.Publishers.First(p => p.Name == "Activision Blizzard")
                },
                new()
                {
                    Title = "Assassin's Creed Syndicate",
                    ReleaseDate = new DateTime(2015,10,23),
                    Summary = "1868 London. The Industrial Revolution. An age of invention and wealth, built on the backs of the working class. As gangster killer Jacob Frye, you recruit a gang to fight for justice on behalf of the oppressed working class. Lead the underworld to reclaim London in an adventure filled with action, intrigue and brutal combat. With Jacob as the leader, players can establish UK's fiercest gang, the only force that can challenge the elite and defeat rival gangs to bring freedom to the oppressed folks. Enemy strongholds can be infiltrated by using an arsenal to dominate London’s underworld. From robbing trains to rescuing child workers, players will do everything they can to bring justice to London’s lawless streets.",
                    Price = 24,
                    Playtime = 37,
                    Publisher = dbContext.Publishers.First(p => p.Name == "Ubisoft")
                },
                new()
                {
                    Title = "Assassin's Creed Unity",
                    ReleaseDate = new DateTime(2014,11,11),
                    Summary = "The city: 1789 Paris. The French Revolution transforms a once-magnificent city into a hot house of terror and calamity. Its cobblestone streets run red with the blood of the proletariat who dared to rise up against the oppressive aristocracy. As the nation is in upheaval, a man named Arno leaves on a journey to expose the true powers of the Revolution. His mission throws him into the middle of a ruthless struggle for the fate of a nation, and transform him into a real Master Assassin. From the storming of the Bastille to the execution of King Louis XVI, experience the French Revolution as never before, and help the people of France carve an entirely new destiny.",
                    Price = 25,
                    Playtime = 17,
                    Publisher = dbContext.Publishers.First(p => p.Name == "Ubisoft")
                },
                new()
                {
                    Title = "FIFA 18",
                    ReleaseDate = new DateTime(2017,9,26),
                    Summary = "Score incredible goals in FIFA 18 as new movement and finishing animations unlock more fluid striking and heading of the ball. All-new crossing controls bring greater options to how you send it into the box. Whipped to the spot, arching deliveries, and pinged crosses to the back-stick will shake up your attacks in the final third. The biggest step in gameplay, FIFA 18 introduces Real Player Motion Technology, an all-new animation system that unlocks the next level of responsiveness and player personality. Now Cristiano Ronaldo and other top players feel and move exactly like they do on the real pitch. From tiki-taka to high press, new Team Styles put the most recognised tactics of the world's best clubs on the pitch in FIFA 18. Enjoy more time and space to read the play through New Player Positioning, while improved tactics give players greater options on the ball as teammates exploit space and make new attacking runs.",
                    Price = 45,
                    Playtime = null,
                    Publisher = dbContext.Publishers.First(p => p.Name == "Electronic Arts")
                },
                new()
                {
                    Title = "F1 22",
                    ReleaseDate = new DateTime(2022,7,1),
                    Summary = "Enter the new era of Formula 1® in EA SPORTS™ F1® 22, the official videogame of the 2022 FIA Formula One World Championship™. Take your seat for a new season as redesigned cars and overhauled rules redefine race day, test your skills around the new Miami International Autodrome, and get a taste of the glitz and glamour in F1® Life. Race the stunning new cars of the Formula 1® 2022 season with the authentic lineup of all 20 drivers and 10 teams, and take control of your race experience with new immersive or broadcast race sequences. Create a team and take them to the front of the grid with new depth in the acclaimed My Team career mode, race head-to-head in split-screen or multiplayer, or change the pace by taking supercars from some of the sport’s biggest names to the track in our all new Pirelli Hot Laps feature.",
                    Price = 40m,
                    Playtime = null,
                    Publisher = dbContext.Publishers.First(p => p.Name == "Electronic Arts")
                },
                new()
                {
                    Title = "Grand Theft Auto: San Andreas",
                    ReleaseDate = new DateTime(2005,7,7),
                    Summary = "Five years ago Carl Johnson escaped from the pressures of life in Los Santos, San Andreas... a city tearing itself apart with gang trouble, drugs and corruption. Where filmstars and millionaires do their best to avoid the dealers and gangbangers. Now, it's the early 90s. Carl's got to go home. His mother has been murdered, his family has fallen apart and his childhood friends are all heading towards disaster. On his return to the neighborhood, a couple of corrupt cops frame him for homicide. CJ is forced on a journey that takes him across the entire state of San Andreas, to save his family and to take control of the streets.",
                    Price = 17m,
                    Playtime = 30.5,
                    Publisher = dbContext.Publishers.First(p => p.Name == "Rockstar Games")
                },
                new()
                {
                    Title = "Tom Clancy's SPLINTER CELL",
                    ReleaseDate = new DateTime(2003,2,13),
                    Summary = "Infiltrate terrorists' positions, acquire critical intelligence by any means necessary, execute with extreme prejudice, and exit without a trace! You are Sam Fisher, a highly trained secret operative of the NSA's secret arm: Third Echelon. The world balance is in your hands, as cyber terrorism and international tensions are about to explode into WWIII.",
                    Price = 12.5m,
                    Playtime = 4.5,
                    Publisher = dbContext.Publishers.First(p => p.Name == "Ubisoft")
                },
                new()
                {
                    Title = "CUPHEAD",
                    ReleaseDate = new DateTime(2017,9,29),
                    Summary = "Cuphead is a classic run and gun action game primarily focused on boss battles. Inspired by the cartoons of the 1930s, the visuals and audio are carefully created with the same techniques of the era, i.e. traditional cel animation (hand drawn & hand inked), watercolor backgrounds, and original jazz recordings. Play as Cuphead or Mugman (in single player or co-op) as you traverse strange worlds, acquire new weapons, learn powerful super moves, and discover hidden secrets.",
                    Price = 13,
                    Playtime = 7,
                    Publisher = dbContext.Publishers.First(p => p.Name == "Warner Bros. Interactive Entertainment")
                },
                new()
                {
                    Title = "Watch Dogs 2",
                    ReleaseDate = new DateTime(2016,11,28),
                    Summary = "Check out the birthplace of the tech revolution as Marcus Holloway, a brilliant young hacker who has fallen victim to ctOS 2.0's predictive algorithms and accused of a crime he did not commit. In Marcus' mission to shut down ctOS 2.0 for good, hacking is his ultimate weapon. Players not only can hack into the San Francisco Bay Area's infrastructure, but also into every person and any connected device they possess to trigger unpredictable chains of events in this vast open world.",
                    Price = 45,
                    Playtime = 19,
                    Publisher = dbContext.Publishers.First(p => p.Name == "Ubisoft")
                }
            };

            dbContext.AddRange(games);
            await dbContext.SaveChangesAsync();
        }
    }
}
