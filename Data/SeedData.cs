using EugeneArtStore.Models;
using Microsoft.AspNetCore.Identity;

namespace EugeneArtStore.Data;

public class SeedData
{
    public static void Seed(ApplicationDbContext context, IServiceProvider provider)
    {
        var userManager = provider
            .GetRequiredService<UserManager<AppUser>>();
        
        //only add users if there are none
        if (!userManager.Users.Any())  
        {
            // Create User objects
            DateOnly date = DateOnly.FromDateTime(DateTime.Now);
            const string SECRET_PASSWORD = "Pass!123";
            AppUser jasonBruce = new AppUser { UserName = "Jason Bruce", AccountAge = date};
            var result = userManager.CreateAsync(jasonBruce, SECRET_PASSWORD);
            
            AppUser wyattQualiana = new AppUser { UserName = "Wyatt Qualiana", AccountAge = date};
            result = userManager.CreateAsync(wyattQualiana, SECRET_PASSWORD);
            
            context.SaveChanges(); 
        }

        if (!context.Products.Any())
        {
            Product prod1 = new Product
            {
                Price = 10.99m,
                Name = "Titanium White Acrylic",
                Description = "100ml Winsor Newton",
                InStock = true
            };
            
            Product prod2 = new Product
            {
                Price = 12.49m,
                Name = "Cadmium Red Acrylic",
                Description = "100ml Winsor Newton",
                InStock = true
            };

            Product prod3 = new Product
            {
                Price = 9.99m,
                Name = "Ultramarine Blue Acrylic",
                Description = "100ml Winsor Newton",
                InStock = false
            };

            Product prod4 = new Product
            {
                Price = 15.99m,
                Name = "Burnt Sienna Oil Paint",
                Description = "200ml Winsor Newton",
                InStock = true
            };

            Product prod5 = new Product
            {
                Price = 7.99m,
                Name = "Lemon Yellow Gouache",
                Description = "30ml Winsor Newton",
                InStock = true
            };

            Product prod6 = new Product
            {
                Price = 5.99m,
                Name = "Graphite Sketching Pencil Set",
                Description = "Set of 6, various hardness",
                InStock = false
            };

            Product prod7 = new Product
            {
                Price = 22.99m,
                Name = "Synthetic Paintbrush Set",
                Description = "Pack of 10, assorted sizes",
                InStock = true
            };

            Product prod8 = new Product
            {
                Price = 29.99m,
                Name = "Cotton Canvas Panel",
                Description = "16x20 inches, triple primed",
                InStock = true
            };

            Product prod9 = new Product
            {
                Price = 19.99m,
                Name = "Acrylic Medium Gloss Gel",
                Description = "250ml Liquitex",
                InStock = true
            };

            Product prod10 = new Product
            {
                Price = 14.99m,
                Name = "Palette Knife Set",
                Description = "Set of 5 stainless steel knives",
                InStock = false
            };
                
            context.Products.Add(prod1);
            context.Products.Add(prod2);
            context.Products.Add(prod3);
            context.Products.Add(prod4);
            context.Products.Add(prod5);
            context.Products.Add(prod6);
            context.Products.Add(prod7);
            context.Products.Add(prod8);
            context.Products.Add(prod9);
            context.Products.Add(prod10);
            context.SaveChanges();
        }

        if (!context.Artworks.Any())
        {
            Artwork art1 = new Artwork
            {
                Title = "Test Work",
                Description = "Test Work Description",
                Link = "https://place-hold.it/200",
                DateFinished = DateOnly.FromDateTime(DateTime.Now)
            };
            
            Artwork art2 = new Artwork
            {
                Title = "Test Work 2",
                Description = "Test Work Description",
                Link = "https://place-hold.it/200",
                DateFinished = DateOnly.FromDateTime(DateTime.Now)
            };
            
            Artwork art3 = new Artwork
            {
                Title = "Test Work 3",
                Description = "Test Work Description",
                Link = "https://place-hold.it/200",
                DateFinished = DateOnly.FromDateTime(DateTime.Now)
            };
            
            Artwork art4 = new Artwork
            {
                Title = "Test Work 4",
                Description = "Test Work Description",
                Link = "https://place-hold.it/200",
                DateFinished = DateOnly.FromDateTime(DateTime.Now)
            };
            
            Artwork art5 = new Artwork
            {
                Title = "Test Work 5",
                Description = "Test Work Description",
                Link = "https://place-hold.it/200",
                DateFinished = DateOnly.FromDateTime(DateTime.Now)
            };
            
            context.Artworks.Add(art1);
            context.Artworks.Add(art2);
            context.Artworks.Add(art3);
            context.Artworks.Add(art4);
            context.Artworks.Add(art5);
            context.SaveChanges();
        }
        
    }
    
    //create admin user
    public static async Task CreateAdminUser(IServiceProvider serviceProvider) 
    {
        UserManager<AppUser> userManager =
            serviceProvider.GetRequiredService<UserManager<AppUser>>(); 
        RoleManager<IdentityRole> roleManager =
            serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        
        string username = "Administrator"; 
        string password = "Pass1234!"; 
        string roleName = "Admin";
        DateOnly date = DateOnly.FromDateTime(DateTime.Now);
        
        // if role doesn't exist, create it
        if (await roleManager.FindByNameAsync(roleName) == null) 
        { 
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
        // if username doesn't exist, create it and add it to role
        if (await userManager.FindByNameAsync(username) == null) 
        { 
            AppUser user = new AppUser { UserName = username, AccountAge = date}; 
            var result = await userManager.CreateAsync(user, password); 
            if (result.Succeeded) {
                await userManager.AddToRoleAsync(user, roleName); 
            }
        } 
    }
}
