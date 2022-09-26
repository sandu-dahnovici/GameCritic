using GameCritic.Domain.Auth;
using Microsoft.AspNetCore.Identity;

namespace GameCritic.Infrastructure.Persistence.DataSeed
{
    public static class RoleSeed
    {
        public static async Task Seed(RoleManager<Role> roleManager)
        {
            if (roleManager.Roles.Any()) return;

            List<Role> roles = new()
            {
                new() { Name = UserRoles.User},
                new() { Name = UserRoles.Admin},
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }
        }
    }
}
