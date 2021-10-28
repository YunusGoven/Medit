using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Medit1.Models.Configuration
{
    public static class DataInitiliazer
    {
        public static async Task SeedData(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            await SeedRole(roleManager);
            await SeedUser(userManager);
        }

        private static async Task SeedUser(UserManager<User> userManager)
        {
            if (userManager.FindByNameAsync("director@test.com").Result == null)
            {
                var user1 = new User() {
                    UserId = 1,
                    Email = "director@test.com",
                    UserName = "director@test.com",
                    Name = "Schettino",
                    FirstName = "François",
                    TwoFactorEnabled = false
                };
                var result =await userManager.CreateAsync(user1, "Jecoule0!0");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user1, "Director");
                }


            }
            if (userManager.FindByNameAsync("user1@test.com").Result == null)
            {
                var user1 = new User() { UserId = 2, Email = "user1@test.com",UserName = "user1@test.com", TwoFactorEnabled = false, Name = "User1" };
                var result = await userManager.CreateAsync(user1, "Test123/");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user1, "Membre");
                }
            }
            if (userManager.FindByNameAsync("user2@test.com").Result == null)
            {
                var user1 = new User() { UserId = 3, Email = "user2@test.com",UserName = "user2@test.com", TwoFactorEnabled = false,Name = "User2"};
                var result = await userManager.CreateAsync(user1, "Test123/");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user1, "Membre");
                }
            }
            if (userManager.FindByNameAsync("user3@test.com").Result == null)
            {
                var user1 = new User() { UserId = 4, Email = "user3@test.com",UserName = "user3@test.com", TwoFactorEnabled = false, Name = "User3" };
                var result = await userManager.CreateAsync(user1, "Test123/");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user1, "Membre");
                }
            }
            if (userManager.FindByNameAsync("user4@test.com").Result == null)
            {
                var user1 = new User() {UserId = 5, Email = "user4@test.com", UserName = "user4@test.com" , TwoFactorEnabled = false, Name = "User4" };
                var result = await userManager.CreateAsync(user1, "Test123/");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user1, "Membre");
                }
            }
        }

        private static async Task SeedRole(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Director"))
            {
                var director = new IdentityRole(){Name = "Director"};
                await roleManager.CreateAsync(director);
            }
            if (!await roleManager.RoleExistsAsync("Membre"))
            {
                var membre = new IdentityRole() { Name = "Membre" };
                await roleManager.CreateAsync(membre);
            }
        }
    }
}
