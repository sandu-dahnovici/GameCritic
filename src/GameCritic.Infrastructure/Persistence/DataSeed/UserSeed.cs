using GameCritic.Domain.Auth;
using Microsoft.AspNetCore.Identity;

namespace GameCritic.Infrastructure.Persistence.DataSeed
{
    public static class UserSeed
    {
        public static async Task Seed(UserManager<User> userManager)
        {
            if (userManager.Users.Any()) return;

            List<User> users = new()
            {
                new()
                {
                    UserName = "sandu1337",
                    Email = "sandu.dahnovici@gmail.com",
                    RegisterDateTime = new(2022,9,20)
                },
                new()
                {
                    UserName = "sebastian_barba",
                    Email = "sebastian.barba@gmail.com",
                    RegisterDateTime = new(2020,5,6)
                },
                new()
                {
                    UserName = "TolikKnight",
                    Email = "tolea.stavila@gmail.com",
                    RegisterDateTime = new(2020,3,3)
                },
                new()
                {
                    UserName = "grcool",
                    Email = "grcool@gmail.com",
                    RegisterDateTime = new(2020,6,8)
                },
                new()
                {
                    UserName = "SilentSeas",
                    Email = "silentseas@gmail.com",
                    RegisterDateTime = new(2021,4,6)
                },
                new()
                {
                    UserName = "Daniel0809",
                    Email = "Daniel0809@gmail.com",
                    RegisterDateTime = new(2019,5,8)
                },
                new()
                {
                    UserName = "Wasptar",
                    Email = "Wasptar@gmail.com",
                    RegisterDateTime = new(2020,1,22)
                },
                new()
                {
                    UserName = "RasmusLuostarin",
                    Email = "RasmusLuostarin@gmail.com",
                    RegisterDateTime = new(2020,7,30)
                },
                new()
                {
                    UserName = "weworkinshadowz",
                    Email = "weworkinshadowz@gmail.com",
                    RegisterDateTime = new(2020,12,22)
                },
                new()
                {
                    UserName = "Owen20",
                    Email = "Owen20@gmail.com",
                    RegisterDateTime = new(2020,12,18)
                },
                new()
                {
                    UserName = "Elrate99",
                    Email = "Elrate99@gmail.com",
                    RegisterDateTime = new(2020,2,21)
                },
                new()
                {
                    UserName = "yuumit",
                    Email = "yuumit0809@gmail.com",
                    RegisterDateTime = new(2020,1,26)
                },
            };

            User user = new()
            {
                UserName = "marcel_mnt",
                Email = "marcel.munteanu@gmail.com"
            };

            await userManager.CreateAsync(users[0], "sandu@123");
            await userManager.AddToRoleAsync(users[0], RoleCategory.Admin);
            await userManager.CreateAsync(users[2], "TolikKnight@123");
            await userManager.AddToRoleAsync(users[2], RoleCategory.Admin);


            await userManager.CreateAsync(users[1], "sebi@123");
            await userManager.AddToRoleAsync(users[1], RoleCategory.User);
            await userManager.CreateAsync(users[3], "grcool@123");
            await userManager.AddToRoleAsync(users[3], RoleCategory.User);
            await userManager.CreateAsync(users[4], "SilentSeas@123");
            await userManager.AddToRoleAsync(users[4], RoleCategory.User);
            await userManager.CreateAsync(users[5], "Daniel0809@123");
            await userManager.AddToRoleAsync(users[5], RoleCategory.User);
            await userManager.CreateAsync(users[6], "Wasptar@123");
            await userManager.AddToRoleAsync(users[6], RoleCategory.User);
            await userManager.CreateAsync(users[7], "RasmusLuostarin@123");
            await userManager.AddToRoleAsync(users[7], RoleCategory.User);
            await userManager.CreateAsync(users[8], "weworkinshadowz@123");
            await userManager.AddToRoleAsync(users[8], RoleCategory.User);
            await userManager.CreateAsync(users[9], "Owen20@123");
            await userManager.AddToRoleAsync(users[9], RoleCategory.User);
            await userManager.CreateAsync(users[10], "Elrate99@123");
            await userManager.AddToRoleAsync(users[10], RoleCategory.User);
            await userManager.CreateAsync(users[11], "yuumit@123");
            await userManager.AddToRoleAsync(users[11], RoleCategory.User);

            await userManager.CreateAsync(user, "marcel@123");
            await userManager.AddToRoleAsync(user, RoleCategory.User);
        }
    }
}
