using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EugeneArtStore.Data;
using EugeneArtStore.Models;

//create builder object
var builder = WebApplication.CreateBuilder(args);

//specify connection string
var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add services to the container.
builder.Services.AddControllersWithViews();

//Example for later
builder.Services.AddTransient<IArtworkRepository, ArtworkRepository>()
    .AddTransient<IStoreRepository, StoreRepository>()
    .AddTransient<IReviewRepository, ReviewRepository>()
    .AddTransient<ICommentRepository, CommentRepository>();

//add Identity
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

//build app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Code for seeding data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider
        .GetRequiredService<ApplicationDbContext>();
    //SeedData.Seed(context, scope.ServiceProvider);
    await SeedData.CreateAdminUser(scope.ServiceProvider);
}

app.Run();