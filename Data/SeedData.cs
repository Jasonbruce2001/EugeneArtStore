using EugeneArtStore.Models;
using Microsoft.AspNetCore.Identity;

namespace EugeneArtStore.Data;

public class SeedData
{
    public static void Seed(ApplicationDbContext context, IServiceProvider provider)
    {
        var userManager = provider
            .GetRequiredService<UserManager<AppUser>>();
        
        if (!context.Products.Any())
        {
            Product prod1 = new Product
            {
                Price = 10.99m,
                Name = "Titanium White Acrylic",
                Description = "100ml Winsor Newton",
                InStock = true,
                PhotoUrl = "https://place-hold.it/400"
            };
            
            Product prod2 = new Product
            {
                Price = 12.49m,
                Name = "Cadmium Red Acrylic",
                Description = "100ml Winsor Newton",
                InStock = true,
                PhotoUrl = "https://place-hold.it/400"
            };

            Product prod3 = new Product
            {
                Price = 9.99m,
                Name = "Ultramarine Blue Acrylic",
                Description = "100ml Winsor Newton",
                InStock = false,
                PhotoUrl = "https://place-hold.it/400"
            };

            Product prod4 = new Product
            {
                Price = 15.99m,
                Name = "Burnt Sienna Oil Paint",
                Description = "200ml Winsor Newton",
                InStock = true,
                PhotoUrl = "https://place-hold.it/400"
            };

            Product prod5 = new Product
            {
                Price = 7.99m,
                Name = "Lemon Yellow Gouache",
                Description = "30ml Winsor Newton",
                InStock = true,
                PhotoUrl = "https://place-hold.it/400"
            };

            Product prod6 = new Product
            {
                Price = 5.99m,
                Name = "Graphite Sketching Pencil Set",
                Description = "Set of 6, various hardness",
                InStock = false,
                PhotoUrl = "https://place-hold.it/400"
            };

            Product prod7 = new Product
            {
                Price = 22.99m,
                Name = "Synthetic Paintbrush Set",
                Description = "Pack of 10, assorted sizes",
                InStock = true,
                PhotoUrl = "https://place-hold.it/400"
            };

            Product prod8 = new Product
            {
                Price = 29.99m,
                Name = "Cotton Canvas Panel",
                Description = "16x20 inches, triple primed",
                InStock = true,
                PhotoUrl = "https://place-hold.it/400"
            };

            Product prod9 = new Product
            {
                Price = 19.99m,
                Name = "Acrylic Medium Gloss Gel",
                Description = "250ml Liquitex",
                InStock = true,
                PhotoUrl = "https://place-hold.it/400"
            };

            Product prod10 = new Product
            {
                Price = 14.99m,
                Name = "Palette Knife Set",
                Description = "Set of 5 stainless steel knives",
                InStock = false,
                PhotoUrl = "https://place-hold.it/400"
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

        if (!context.Reviews.Any())
        {
            DateOnly date = DateOnly.FromDateTime(DateTime.Now);
            const string SECRET_PASSWORD = "Pass123!";
            AppUser rev = new AppUser { UserName = "Reviewer", AccountAge = date};
            var result = userManager.CreateAsync(rev, SECRET_PASSWORD);
            context.SaveChanges();

            Review rev1 = new Review
            {
                Id = 1,
                ProductId = 1,
                Author = rev,
                Content =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec porttitor erat vitae justo consequat posuere. " +
                    "Pellentesque tristique iaculis lectus eget consequat. Aliquam eu consequat purus, eu malesuada ante. Morbi " +
                    "tempus vehicula turpis, et tempus enim blandit eget. Suspendisse condimentum nisi convallis fermentum varius. " +
                    "Nunc blandit quam id ex dictum, vel tincidunt diam feugiat. Maecenas condimentum magna id dignissim ultricies.",
                Helpful = 5,
                Rating = 10,
                DateCreated = DateTime.Now
            };
            Review rev2 = new Review
            {
                Id = 2,
                ProductId = 1,
                Author = rev,
                Content =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec porttitor erat vitae justo consequat posuere. " +
                    "Pellentesque tristique iaculis lectus eget consequat. Aliquam eu consequat purus, eu malesuada ante. Morbi " +
                    "tempus vehicula turpis, et tempus enim blandit eget. Suspendisse condimentum nisi convallis fermentum varius. " +
                    "Nunc blandit quam id ex dictum, vel tincidunt diam feugiat. Maecenas condimentum magna id dignissim ultricies.",
                Helpful = 1,
                Rating = 7,
                DateCreated = DateTime.Now
            };
            Review rev3 = new Review
            {
                Id = 3,
                ProductId = 1,
                Author = rev,
                Content =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec porttitor erat vitae justo consequat posuere. " +
                    "Pellentesque tristique iaculis lectus eget consequat. Aliquam eu consequat purus, eu malesuada ante. Morbi " +
                    "tempus vehicula turpis, et tempus enim blandit eget. Suspendisse condimentum nisi convallis fermentum varius. " +
                    "Nunc blandit quam id ex dictum, vel tincidunt diam feugiat. Maecenas condimentum magna id dignissim ultricies.",
                Helpful = 50,
                Rating = 3,
                DateCreated = DateTime.Now
            };
            
            context.Reviews.Add(rev1);
            context.Reviews.Add(rev2);
            context.Reviews.Add(rev3);
            context.SaveChanges(); 
        }

        if (!context.Artworks.Any())
        {
            // Create User objects
            DateOnly date = DateOnly.FromDateTime(DateTime.Now);
            const string SECRET_PASSWORD = "Pass!123";
            AppUser author = new AppUser { UserName = "TestAuthor", AccountAge = date};
            var result = userManager.CreateAsync(author, SECRET_PASSWORD);
            context.SaveChanges();
            
            Artwork art1 = new Artwork
            {
                Title = "Test Work",
                Author = author,
                Description = "Test Work Description",
                Link = "https://place-hold.it/200",
                DatePosted = DateOnly.FromDateTime(DateTime.Now)
            };
            
            Artwork art2 = new Artwork
            {
                Title = "Test Work 2",
                Author = author,
                Description = "Test Work Description",
                Link = "https://place-hold.it/200",
                DatePosted = DateOnly.FromDateTime(DateTime.Now)
            };
            
            Artwork art3 = new Artwork
            {
                Title = "Test Work 3",
                Author = author,
                Description = "Test Work Description",
                Link = "https://place-hold.it/200",
                DatePosted = DateOnly.FromDateTime(DateTime.Now)
            };
            
            Artwork art4 = new Artwork
            {
                Title = "Test Work 4",
                Author = author,
                Description = "Test Work Description",
                Link = "https://place-hold.it/200",
                DatePosted = DateOnly.FromDateTime(DateTime.Now)
            };
            
            Artwork art5 = new Artwork
            {
                Title = "Test Work 5",
                Author = author,
                Description = "Test Work Description",
                Link = "https://place-hold.it/200",
                DatePosted = DateOnly.FromDateTime(DateTime.Now)
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
