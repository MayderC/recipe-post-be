using Microsoft.EntityFrameworkCore;
using Recipes.Application.Entities;

namespace Recipes.Database.Data;

public class DataContext : DbContext
{
    public  DataContext() {}
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(U => U.Username)
            .IsUnique();
        modelBuilder.Entity<User>()
            .HasIndex(U => U.Email)
            .IsUnique();
        modelBuilder.Entity<Ingredient>()
            .HasOne(i => i.Size)
            .WithMany()
            .HasForeignKey(i => i.SizeId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Recipe>()
            .HasOne(r => r.Location)
            .WithMany()
            .HasForeignKey(r => r.LocationId)
            .OnDelete(DeleteBehavior.NoAction);
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<RecipeTag> RecipeTags { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<LookUpItem> LookUpItems { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    
}