using GameCritic.Domain.Auth;
using GameCritic.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace GameCritic.Infrastructure.Persistence.DataSeed
{
    public static class ReviewSeed
    {
        public static async Task Seed(GameCriticDbContext dbContext, UserManager<User> userManager)
        {
            if (dbContext.Reviews.Any()) return;

            // i forgot creation date but it was later generated in database :) 

            List<Review> reviews = new()
            {
                new()
                {
                    Mark = 10,
                    Comment = "Amazing game, singleplayer part of course. But where's GTA 6, it's been like 7 years? Rockstar? U alive? lol",
                    Game = dbContext.Games.First(g => g.Title == "Grand Theft Auto V"),
                    User = userManager.Users.First(u => u.UserName == "sebastian_barba"),
                },
                new()
                {
                    Mark = 10,
                    Comment = "I have played GTA 5 every year at least once since 2015 when it came out and i'm still not bored of it. Rockstar really did something right with this one. I'm so hyped for GTA 6.",
                    Game = dbContext.Games.First(g => g.Title == "Grand Theft Auto V"),
                    User = userManager.Users.First(u => u.UserName == "grcool"),
                },
                new()
                {
                    Mark = 8,
                    Comment = "Graphics - 8/10,Gameplay - 9/10,Management - 8/10,Detailing - 8/10,Optimization - 6/10,The plot part - 9/10,Interesting - 7/10,Personal tastes - 9/10,Sound - 7/10,Physics - 8/10,Mechanics - 9/10,How quickly you get bored - -3/-10,Bugs - -3/10",
                    Game = dbContext.Games.First(g => g.Title == "Grand Theft Auto V"),
                    User = userManager.Users.First(u => u.UserName == "SilentSeas"),
                },
                new()
                {
                    Mark = 7,
                    Comment = "дота 2 крекер дота 2 крекер дота 2 крекер дота 2 крекер дота 2 крекер дота 2 крекер",
                    Game = dbContext.Games.First(g => g.Title == "Grand Theft Auto V"),
                    User = userManager.Users.First(u => u.UserName == "Daniel0809"),
                },
                new()
                {
                    Mark = 3,
                    Comment = "The story mode is great but the online mode is ruined since there are modderns in every single lobby and you get blown up 24/7. Rockstar is not doing a thing against all the modders. nothing has been better. this game sucks... don't buy it rather burn the money",
                    Game = dbContext.Games.First(g => g.Title == "Grand Theft Auto V"),
                    User = userManager.Users.First(u => u.UserName == "Wasptar"),
                },
                new()
                {
                    Mark = 2,
                    Comment = "Due to free distribution of game i have about half time failed connection. Also into the game came more much \"garbage people\" (moders).",
                    Game = dbContext.Games.First(g => g.Title == "Grand Theft Auto V"),
                    User = userManager.Users.First(u => u.UserName == "RasmusLuostarin"),
                },
                new()
                {
                    Mark = 9,
                    Comment = "Too hard for me, always hit on the road. Just starting to play it. Too many dirty words.",
                    Game = dbContext.Games.First(g => g.Title == "Grand Theft Auto V"),
                    User = userManager.Users.First(u => u.UserName == "weworkinshadowz"),
                },
                new()
                {
                    Mark = 10,
                    Comment = "good game, you can do lot of things, playing online with friends or playing alone.",
                    Game = dbContext.Games.First(g => g.Title == "Grand Theft Auto V"),
                    User = userManager.Users.First(u => u.UserName == "Owen20"),
                },
                new()
                {
                    Mark = 7,
                    Comment = "Runs decent and quite some singleplayer content. Multiplayer has lots of content, but can be dependent on other people internet which means some coop is extremely laggy and unplayable. The game has gotten no singleplayer content after release, which is sad. Instead it's focused on microtransactions for multiplayer.",
                    Game = dbContext.Games.First(g => g.Title == "Grand Theft Auto V"),
                    User = userManager.Users.First(u => u.UserName == "Elrate99"),
                },
                new()
                {
                    Mark = 10,
                    Comment = "Campanha? Sensacional! Um dos melhores jogos que já joguei. Modo Online? Hoje em dia é um lixo completo! Mas o foco é no modo campanha, então por ela eu dou uma nota boa.",
                    Game = dbContext.Games.First(g => g.Title == "Grand Theft Auto V"),
                    User = userManager.Users.First(u => u.UserName == "yuumit"),
                },
                new()
                {
                    Mark = 10,
                    Comment = "This game is FPS at its best! No matter how many times you play it, youll either crap your pants or have your mind explode out of the sheer…",
                    Game = dbContext.Games.First(g => g.Title == "Half-life 2"),
                    User = userManager.Users.First(u => u.UserName == "yuumit"),
                },
                new()
                {
                    Mark = 8,
                    Comment = "Amazing game that does everything it sets out to do near perfectly, and still holds up incredibly well today. Not to mention it can run on a potato",
                    Game = dbContext.Games.First(g => g.Title == "Half-life 2"),
                    User = userManager.Users.First(u => u.UserName == "SilentSeas"),
                },
                new()
                {
                    Mark = 9,
                    Comment = "Great game, maybe the best game I played",
                    Game = dbContext.Games.First(g => g.Title == "Half-life 2"),
                    User = userManager.Users.First(u => u.UserName == "RasmusLuostarin"),
                },
                new()
                {
                    Mark = 10,
                    Comment = "I would rate it 20/10 if i could, the only problem with the game was \"Steam.\" When i bought the game i was so Pis**d Off because i could not play it because i did not have the internet at the time so i installed it on someone else's computer to play it, later to find out they didn't have a good enough graphics card so that didn't help.",
                    Game = dbContext.Games.First(g => g.Title == "Half-life 2"),
                    User = userManager.Users.First(u => u.UserName == "sebastian_barba"),
                },
                new()
                {
                    Mark = 10,
                    Comment = "Definitely best action-rpg game all time. Not the best action game or not the best rpg game but this is definitely best action-rpg if you want to play game with its own universe Witcher Universe is the best for you with all games",
                    Game = dbContext.Games.First(g => g.Title == "The Witcher 3: Wild Hunt"),
                    User = userManager.Users.First(u => u.UserName == "yuumit"),
                },
                new()
                {
                    Mark = 9,
                    Comment = "A true masterpiece. Characters are well written as is the story. Feel and aesthetic of the world is great. And the music is amazing!",
                    Game = dbContext.Games.First(g => g.Title == "The Witcher 3: Wild Hunt"),
                    User = userManager.Users.First(u => u.UserName == "Elrate99"),
                },
                new()
                {
                    Mark = 7,
                    Comment = null,
                    Game = dbContext.Games.First(g => g.Title == "The Witcher 3: Wild Hunt"),
                    User = userManager.Users.First(u => u.UserName == "Owen20"),
                },
                new()
                {
                    Mark = 9,
                    Comment = "Best game i have ever played. The story is amazing i would advise playing witcher 2 before playing this.",
                    Game = dbContext.Games.First(g => g.Title == "The Witcher 3: Wild Hunt"),
                    User = userManager.Users.First(u => u.UserName == "weworkinshadowz"),
                },
                new()
                {
                    Mark = 10,
                    Comment = "Мне не будет скучно, если я играл в эту игру тысячи раз.Я никогда не видел такой замечательной игры.Лучшая игра!!",
                    Game = dbContext.Games.First(g => g.Title == "The Witcher 3: Wild Hunt"),
                    User = userManager.Users.First(u => u.UserName == "RasmusLuostarin"),
                },
                new()
                {
                    Mark = 8,
                    Comment = "An absolute unit of a game. Amazing characters. Perfect story. Brilliant gameplay. Stunning visuals. Geralts voice. what more could you want? A few hundred hours of gameplay well spent, okay have that too then.",
                    Game = dbContext.Games.First(g => g.Title == "The Witcher 3: Wild Hunt"),
                    User = userManager.Users.First(u => u.UserName == "Wasptar"),
                },
                new()
                {
                    Mark = 10,
                    Comment = "Sensational Game! The mechanics have been improved over the previous game, combat is very fluid and the evolution of the character is sensitive to each level. The map is huge, with very interesting sidequests. The expansions add a lot to the game. For the prices shown in the promotion, the game + Expansions is almost free.",
                    Game = dbContext.Games.First(g => g.Title == "The Witcher 3: Wild Hunt"),
                    User = userManager.Users.First(u => u.UserName == "Daniel0809"),
                },
                new()
                {
                    Mark = 9,
                    Comment = "memorable characters, amazing music, graphics just everything top notch, my only problem with the game would be the combat being boring at times, its still a 10, masterpiece",
                    Game = dbContext.Games.First(g => g.Title == "The Witcher 3: Wild Hunt"),
                    User = userManager.Users.First(u => u.UserName == "SilentSeas"),
                },
                new()
                {
                    Mark = 10,
                    Comment = "This is the best game I have ever played! Great storyline! Crafted characters! Great music and sound! All in all, this is the best game.",
                    Game = dbContext.Games.First(g => g.Title == "The Witcher 3: Wild Hunt"),
                    User = userManager.Users.First(u => u.UserName == "grcool"),
                },
                new()
                {
                    Mark = 10,
                    Comment = "You know if a game goes as far as detail to make you brew coffee via campfire before drinking it, or getting your weapons from a horse's satchel, or literally watching it's testicles shrink in cold weather, that this is game of the decade material.",
                    Game = dbContext.Games.First(g => g.Title == "Red Dead Redemption 2"),
                    User = userManager.Users.First(u => u.UserName == "Wasptar"),
                },
                new()
                {
                    Mark = 10,
                    Comment = null,
                    Game = dbContext.Games.First(g => g.Title == "Red Dead Redemption 2"),
                    User = userManager.Users.First(u => u.UserName == "SilentSeas"),
                },
                new()
                {
                    Mark = 10,
                    Comment = "This is the best I've played in the last three years. Thank you to Rockstar",
                    Game = dbContext.Games.First(g => g.Title == "Red Dead Redemption 2"),
                    User = userManager.Users.First(u => u.UserName == "weworkinshadowz"),
                },
                new()
                {
                    Mark = 8,
                    Comment = "The game that introduced me to the competitive FPS scene. Brilliant game, great gunplay, and utterly groundbreaking for its time. This and Call of Duty: World at War, are the pinnacle of CoD. This franchise needs to go back to MW and WaW if it hopes to survive. The modern CoD games can't hold a candle to this one.",
                    Game = dbContext.Games.First(g => g.Title == "Call Of Duty 4: Modern Warfare"),
                    User = userManager.Users.First(u => u.UserName == "RasmusLuostarin"),
                },
                new()
                {
                    Mark = 10,
                    Comment = "I LOVE THİS GAME AND I MİSS SO MUCH.Activison must be create new modern warfare series because lots of call of duty fans wants come back modern warfare.",
                    Game = dbContext.Games.First(g => g.Title == "Call Of Duty 4: Modern Warfare"),
                    User = userManager.Users.First(u => u.UserName == "Daniel0809"),
                },
                new()
                {
                    Mark = 9,
                    Comment = "Nice story! But world at war gives the real thrill of old days ! And what more, its banal when you re create world war themes after there is a world at war ... world at war 10! Modern warfare 8 is enough!",
                    Game = dbContext.Games.First(g => g.Title == "Call Of Duty 4: Modern Warfare"),
                    User = userManager.Users.First(u => u.UserName == "sebastian_barba"),
                },
                new()
                {
                    Mark = 8,
                    Comment = "The best FPS so far. I do how ever miss large maps and vehicles as we had in joint, and I'm loking forward to ARMA2. These games how ever can not be directly compared as there are two compleatly different gaming styles",
                    Game = dbContext.Games.First(g => g.Title == "Call Of Duty 4: Modern Warfare"),
                    User = userManager.Users.First(u => u.UserName == "Elrate99"),
                },
                new()
                {
                    Mark =10 ,
                    Comment = "The best game ever. Game of the Year 2020. Masterpiece storyline and gameplay.",
                    Game = dbContext.Games.First(g => g.Title == "CYBERPUNK 2077"),
                    User = userManager.Users.First(u => u.UserName == "grcool"),
                },
                new()
                {
                    Mark = 6,
                    Comment = "I can run this game quite well with gtx1060 in 1080p and have a decent performance. But guys, there are so many bugs. It is very hard to enjoy cut scenes when here and there you see floating and flickering textures.\nThe game is not any kind of innovative. It feels like playing an advanced version of Deus Ex. \nEven with al bugs patched this game is too boring second-class journey.",
                    Game = dbContext.Games.First(g => g.Title == "CYBERPUNK 2077"),
                    User = userManager.Users.First(u => u.UserName == "sebastian_barba"),
                },
                new()
                {
                    Mark = 8,
                    Comment = "too many glitches but i still wanna give this game for 8 out of 10 play it after few months",
                    Game = dbContext.Games.First(g => g.Title == "CYBERPUNK 2077"),
                    User = userManager.Users.First(u => u.UserName == "SilentSeas"),
                },
                new()
                {
                    Mark = 7,
                    Comment = null,
                    Game = dbContext.Games.First(g => g.Title == "CYBERPUNK 2077"),
                    User = userManager.Users.First(u => u.UserName == "Wasptar"),
                },
                new()
                {
                    Mark = 9,
                    Comment = "Coooooool, insanely beautiful game, stunning storyline and characters this game immerses you in it, good gameplay, shooting, driving and stuff, a variety of missions, of the minuses: bugs, optimization, crashes, but i love this game",
                    Game = dbContext.Games.First(g => g.Title == "CYBERPUNK 2077"),
                    User = userManager.Users.First(u => u.UserName == "Daniel0809"),
                },
                new()
                {
                    Mark = 9,
                    Comment = "It delivers in everything i expected.\nThe city is beyond beautifull, feels handcrafted and the lighting is amazing. The voice acting is great.! And general sound super immersive. ",
                    Game = dbContext.Games.First(g => g.Title == "CYBERPUNK 2077"),
                    User = userManager.Users.First(u => u.UserName == "weworkinshadowz"),
                },
                new()
                {
                    Mark = 8,
                    Comment = "Ok game!",
                    Game = dbContext.Games.First(g => g.Title == "Mortal Kombat 11"),
                    User = userManager.Users.First(u => u.UserName == "weworkinshadowz"),
                },
                new()
                {
                    Mark = 10,
                    Comment = "I'm almost shocked how well Ubisoft delivered with this one. 2019 was awful for them, so i wasn't expecting much, but Valhalla so good. There's so much to do, voice acting is great, story is great, graphics are amazing. It's going to be something i'm gonna play until cyberpunk comes out. There's not much else anyway. Not interested at all in spiderman dlc",
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Valhalla"),
                    User = userManager.Users.First(u => u.UserName == "grcool"),
                },
                new()
                {
                    Mark = 9,
                    Comment = "Maybe little bit early to review it, because i haven't finished main story, but i like it a lot.\nI hardly had any interest in missions in Odyssey, but Valhalla is different. Might be one of the best games i have played this year, alongside Doom Eternal.",
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Valhalla"),
                    User = userManager.Users.First(u => u.UserName == "sebastian_barba"),
                },
                new()
                {
                    Mark = 9,
                    Comment = "Okay short review : game is good, better than odyssey. Haters are angry because this game was huge hit so they will leave 0/10 reviews and pretend like it's bad game. People enjoy this game regardless, because nobody cares what some sad haters say. Life goes on. The end.",
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Valhalla"),
                    User = userManager.Users.First(u => u.UserName == "SilentSeas"),
                },
                new()
                {
                    Mark = 7,
                    Comment = "Generally it's not nearly as bad some people pretend it to be, i have a feeling these people haven't even tried it. Watching two youtube videos doesn't count. Map is big, there's a lot stuff to do. ",
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Valhalla"),
                    User = userManager.Users.First(u => u.UserName == "Wasptar"),
                },
                new()
                {
                    Mark = 5,
                    Comment = "This game does not deserve the score it has. Audio is very poorly compressed and even though soundtrack is very good they didn't use them much idk why. Dialogues are so badly written everything feels like rushed. Characters aren't interesting not even Eivor's because they filled the game with unnecessary alliance grinding. Mid game is so boring idk how im gonna finish this.",
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Valhalla"),
                    User = userManager.Users.First(u => u.UserName == "Daniel0809"),
                },
                new()
                {
                    Mark = 10,
                    Comment = "Assassin’s Creed Valhalla is the best open world RPG this year. It’s colorful locals are a joy to discover, combat and stealth feel deep and rewarding, and there’s a viking hoard of things to do.",
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Valhalla"),
                    User = userManager.Users.First(u => u.UserName == "weworkinshadowz"),
                },
                new()
                {
                    Mark = 9,
                    Comment = "Valhalla is a truly authentic Viking experience, and quite possibly the best and most complete Assassin's Creed game in the series' current \"Open-World RPG\" phase.",
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Valhalla"),
                    User = userManager.Users.First(u => u.UserName == "yuumit"),
                },
                new()
                {
                    Mark = 8,
                    Comment = "Pretty fine open world game that got hit by bunch of haters who never even tried it. It was never meant to be gta 5 successor, there's gta 6 for that (who knows when that comes out).",
                    Game = dbContext.Games.First(g => g.Title == "Watch Dogs: Legion"),
                    User = userManager.Users.First(u => u.UserName == "yuumit"),
                },
                new()
                {
                    Mark = 7,
                    Comment = "Just another mediocre Ubisoft open-world game, but the near future London is till kind of beautiful tho",
                    Game = dbContext.Games.First(g => g.Title == "Watch Dogs: Legion"),
                    User = userManager.Users.First(u => u.UserName == "Wasptar"),
                },
                new()
                {
                    Mark = 5,
                    Comment = "This call of duty was boring as hell.One of the worst zombies in call of duty games with literally no campaign",
                    Game = dbContext.Games.First(g => g.Title == "Call Of Duty: Black Ops 4"),
                    User = userManager.Users.First(u => u.UserName == "weworkinshadowz"),
                },
                new()
                {
                    Mark = 8,
                    Comment = "Game is honestly very surprising to me. Didn't really expect it to be this good. It's got 3 modes that are all fun and replayable, no campaign so they can focus more on the other modes, and its very fun to play with friends. If you've got the console (or a PC that can run it), if you've got the money, I think it's all worth it.",
                    Game = dbContext.Games.First(g => g.Title == "Call Of Duty: Black Ops 4"),
                    User = userManager.Users.First(u => u.UserName == "grcool"),
                },
                new()
                {
                    Mark = 6,
                    Comment = "Very nice call of duty its the best for PS4.\nWe had to see i call of duty like that from cod ghosts.\nWell down to activision for this game and to stop double jumping they are in a very good road",
                    Game = dbContext.Games.First(g => g.Title == "Call Of Duty: Black Ops 4"),
                    User = userManager.Users.First(u => u.UserName == "SilentSeas"),
                },
                new()
                {
                    Mark = 8,
                    Comment = "Pretty nice shooting game",
                    Game = dbContext.Games.First(g => g.Title == "Call Of Duty: Black Ops III"),
                    User = userManager.Users.First(u => u.UserName == "SilentSeas"),
                },
                new()
                {
                    Mark = 9,
                    Comment = "It is worth saying that I played the game in 2022 and most of the bugs I saw in previous reviews were not present when I played, This always reinforces my personal belief that playing games at launch is a cold both for the amount paid and for the product delivered.",
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Syndicate"),
                    User = userManager.Users.First(u => u.UserName == "RasmusLuostarin"),
                },
                new()
                {
                    Mark = 7,
                    Comment = "Assassins Creed Syndicate suffers from similar conditions like the rest of the recent AC games. It lacks ambition. The game is decent, and has some fun in it, but at the end of the day it is just better AC: Unity. Its not a disaster from the optimization and bug part, but still when it comes to story and gameplay, it is all very similar, with the exception of likable protagonists twins Eve and Jacob.",
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Syndicate"),
                    User = userManager.Users.First(u => u.UserName == "Wasptar"),
                },
                new()
                {
                    Mark = 4,
                    Comment = "Ubisoft this game is not what we wanted. In order to make it run with older graphics cards you ruined its graphics, you eliminated lots and lots of details. I think it's not a good thing. As for the gameplay the game is uninspired and flat. No emotional feelings in playing it at all.",
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Syndicate"),
                    User = userManager.Users.First(u => u.UserName == "sebastian_barba"),
                },
                new()
                {
                    Mark = 6,
                    Comment = null,
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Syndicate"),
                    User = userManager.Users.First(u => u.UserName == "Owen20"),
                },
                new()
                {
                    Mark = 9,
                    Comment = "Really fun, with an extraordinary atmosphere, to please the fans and engage new to the franchise, much more polished than Unity, Ubisoft moves on right direction again.",
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Syndicate"),
                    User = userManager.Users.First(u => u.UserName == "Elrate99"),
                },
                new()
                {
                    Mark = 8,
                    Comment = "Misunderstood and extremely underrated MASTERPIECE. I would do anything to go back in time and tell the developers to delay it until February 2015 to avoid this awful launch. Either way, now it's 99% fixed and amazing.",
                    Game = dbContext.Games.First(g => g.Title == "Assassin's Creed Unity"),
                    User = userManager.Users.First(u => u.UserName == "Elrate99"),
                },
                new()
                {
                    Mark = 6,
                    Comment = "Presentation and graphics are beautiful and they game play is enjoyable with great atmospheres at games. But defending is none existent and has ruined the game for me and all i can do is watch them simply run past me. I did the training but its one thing in training and another in a match. Love playing the game but please fix the defending. The journey is fun but when the hell are we interested in the MLS ? who cares about the MLS when there are great leagues all over the world. The MLS is poor and rather it been focused on a lower league team in EFL or another european team.",
                    Game = dbContext.Games.First(g => g.Title == "FIFA 18"),
                    User = userManager.Users.First(u => u.UserName == "Owen20"),
                },
                new()
                {
                    Mark = 7,
                    Comment = "Definitely solid in terms of presentation and game modes, even though The Journey is still far from perfect, FIFA 18 sadly feels like a FIFA 17.5 with a lot of emphasis on attack - which can please a lot of players but not those who are looking for something fresh and some football games with a realistic pace.",
                    Game = dbContext.Games.First(g => g.Title == "FIFA 18"),
                    User = userManager.Users.First(u => u.UserName == "SilentSeas"),
                },
                new()
                {
                    Mark = 7,
                    Comment = "They fixed a many since begin. Now its a solid game. I think, its better than F1 21",
                    Game = dbContext.Games.First(g => g.Title == "F1 22"),
                    User = userManager.Users.First(u => u.UserName == "Owen20"),
                },
                new()
                {
                    Mark = 9,
                    Comment = "F1 22 is great I love how the my team works with budget types and I love the new cars",
                    Game = dbContext.Games.First(g => g.Title == "F1 22"),
                    User = userManager.Users.First(u => u.UserName == "weworkinshadowz"),
                },
                new()
                {
                    Mark = 2,
                    Comment = "Everything EA touches turns to **** just like all their sports games the game is the same from last year, but with more bugs, with features taken out and with less refined and polished gameplay and graphics, **** EA",
                    Game = dbContext.Games.First(g => g.Title == "F1 22"),
                    User = userManager.Users.First(u => u.UserName == "Elrate99"),
                },
                new()
                {
                    Mark = 3,
                    Comment = "This game is an Alpha version full of bugs. I don't know how stupid you can be to release this game. Also no feedback from Codies ea about the patch. Like they took the money and disappeared.",
                    Game = dbContext.Games.First(g => g.Title == "F1 22"),
                    User = userManager.Users.First(u => u.UserName == "sebastian_barba"),
                },
                new()
                {
                    Mark = 4,
                    Comment = "BUYER BEWARE\nIn order to play online, you need an EA account. Turns out EA deleted my account and support said to reactivate the account using the email address that created the account, but I'm using the account...",
                    Game = dbContext.Games.First(g => g.Title == "F1 22"),
                    User = userManager.Users.First(u => u.UserName == "grcool"),
                },
                new()
                {
                    Mark = 10,
                    Comment = null,
                    Game = dbContext.Games.First(g => g.Title == "Grand Theft Auto: San Andreas"),
                    User = userManager.Users.First(u => u.UserName == "grcool"),
                },
                new()
                {
                    Mark = 9,
                    Comment = "Amazing game!",
                    Game = dbContext.Games.First(g => g.Title == "Grand Theft Auto: San Andreas"),
                    User = userManager.Users.First(u => u.UserName == "sebastian_barba"),
                },
                new()
                {
                    Mark = 8,
                    Comment = "One of the genre-defining games. Sam Fisher is an icon and later games got even better.",
                    Game = dbContext.Games.First(g => g.Title == "Tom Clancy's SPLINTER CELL"),
                    User = userManager.Users.First(u => u.UserName == "Elrate99"),
                },
                new()
                {
                    Mark = 10,
                    Comment = "Best Game out There Definitely buy it.",
                    Game = dbContext.Games.First(g => g.Title == "Tom Clancy's SPLINTER CELL"),
                    User = userManager.Users.First(u => u.UserName == "Daniel0809"),
                },
                new()
                {
                    Mark = 9,
                    Comment = "This game is the best with all the best sound graphics and levels puls how much deatial is put in to the guns this is a sweet game i would recommend this to anyone.",
                    Game = dbContext.Games.First(g => g.Title == "Tom Clancy's SPLINTER CELL"),
                    User = userManager.Users.First(u => u.UserName == "RasmusLuostarin"),
                },
                new()
                {
                    Mark = 6,
                    Comment = "After the disappointment that was first Watch Dogs, i initially skipped Watch Dogs 2 upon its launch like many other people, but here i am in late 2018 having completed the sequel and while its not the big improvement i hoped it would be, its still a step in the right direction.",
                    Game = dbContext.Games.First(g => g.Title == "Watch Dogs 2"),
                    User = userManager.Users.First(u => u.UserName == "Daniel0809"),
                },
                new()
                {
                    Mark = 9,
                    Comment = "Awesome game, PC version runs well to!! This is a vast improvement over the first game, the writing is much better, the online aspects are improved and the new gadgets and such are great to. Pick this up asap, this is the game Watch Dogs 1 should have been. Oh yeah and the game world is wonderful, makes me want to visit San Fran. ",
                    Game = dbContext.Games.First(g => g.Title == "Watch Dogs 2"),
                    User = userManager.Users.First(u => u.UserName == "RasmusLuostarin"),
                },
                new()
                {
                    Mark = 10,
                    Comment = "I loved Watch Dogs 2.\nThe story is fun. The characters are good and unique. It is not as gloomy as the first Watch Dogs so I think more people will enjoy it. Side content was okay.\nGraphics are great. The game is very colorful and the world has tons of detail. One of the best looking games I have played, the world feels alive.",
                    Game = dbContext.Games.First(g => g.Title == "Watch Dogs 2"),
                    User = userManager.Users.First(u => u.UserName == "Owen20"),
                },
                new()
                {
                    Mark = 9,
                    Comment = "Although Watch Dogs 2 hasn't redefined gaming, it's definitely an innovative game. The gameplay is very good and the way we're able to utilize remote control cars and drones to complete missions is brilliant and adds a lot of fun to the game.",
                    Game = dbContext.Games.First(g => g.Title == "Watch Dogs 2"),
                    User = userManager.Users.First(u => u.UserName == "sebastian_barba"),
                },
                new()
                {
                    Mark = 7,
                    Comment = null,
                    Game = dbContext.Games.First(g => g.Title == "Watch Dogs 2"),
                    User = userManager.Users.First(u => u.UserName == "yuumit"),
                },
                new()
                {
                    Mark = 8,
                    Comment = "The game is not a masterpiece, but not **** either. Considering what was vac dogs 1, 2 part is clear horseradish is better than 1 part.",
                    Game = dbContext.Games.First(g => g.Title == "Watch Dogs 2"),
                    User = userManager.Users.First(u => u.UserName == "grcool"),
                },

            };

            dbContext.AddRange(reviews);
            await dbContext.SaveChangesAsync();
        }
    }
}
