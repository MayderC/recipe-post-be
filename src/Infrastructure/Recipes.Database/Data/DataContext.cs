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
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<RecipeTag> RecipeTags { get; set; }
}