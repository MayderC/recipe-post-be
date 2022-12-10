using Microsoft.EntityFrameworkCore;
using Recipes.Application.Entities;

namespace Recipes.Database.Data;

public class RecipesContext : DbContext
{
    public RecipesContext(DbContextOptions<RecipesContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Tag> Tags { get; set; }
}