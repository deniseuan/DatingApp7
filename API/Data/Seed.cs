using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using API.Entities;
using API.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedProductsAsync(DataContext context)
        {
            if (await context.Products.AnyAsync()) return;

            var products = Utils.seedingProducts;

            context.Products.AddRange(products);

            await context.SaveChangesAsync();
        }

        public static async Task SeedBrandsAsync(DataContext context)
        {
            if (await context.Brands.AnyAsync()) return;

            var data = Utils.seedingBrands;

            context.Brands.AddRange(data);

            await context.SaveChangesAsync();
        }

        public static async Task RelateProductsToBrandsAsync(DataContext context)
        {
            if (await context.ProductBrands.AnyAsync()) return;

            Random rand = new();
            
            var products = await context.Products.ToListAsync();
            var brands = await context.Brands
                .AsNoTracking()
                .ToListAsync();

            foreach (var product in products)
            {
                product.ProductBrand = new (rand.Next(1, brands.Count));
            }

            await context.SaveChangesAsync();
        }
        
        public static async Task SeedUsers(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if(await userManager.Users.AnyAsync()) return;
            
            var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");

            var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};

            var users = JsonSerializer.Deserialize<List<AppUser>>(userData, options);

            var roles = new List<AppRole>
            {
                new AppRole{Name = "Member"},
                new AppRole{Name = "Admin"},
                new AppRole{Name = "Moderator"}
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }


            foreach (var user in users){

                user.UserName = user.UserName.ToLower();

                await userManager.CreateAsync(user, "Pa$$w0rd");

                await userManager.AddToRoleAsync(user, "Member");
            }

            var Admin = new AppUser
            {
                UserName = "admin"
            };

            await userManager.CreateAsync(Admin, "Pa$$w0rd");
            await userManager.AddToRolesAsync(Admin, new[] {"Admin", "Moderator"});
        }
    }
}