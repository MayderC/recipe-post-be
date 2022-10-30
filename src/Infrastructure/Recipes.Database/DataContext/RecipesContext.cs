using Microsoft.EntityFrameworkCore;
using Recipes.Application.Entities;

namespace Recipes.Database.DataContext;

public class RecipesContext : DbContext
{

    public RecipesContext(DbContextOptionsBuilder profile) : base() { }
        
    public DbSet<User> Users { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Tag> Tags { get; set; }
    
}