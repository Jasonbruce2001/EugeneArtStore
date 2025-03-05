using EugeneArtStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EugeneArtStore.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    // constructor just calls the base class constructor
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    // one DbSet for each domain model class
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<Product> Products { get; set; }
    //public DbSet<Review> Reviews { get; set; }
}