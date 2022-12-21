using Microsoft.EntityFrameworkCore;
using Recipes.Application.Entities;
using Recipes.Application.Repositories;
using Recipes.Database.Data;

namespace Recipes.Adapter.Repositories;

public class RecipeTagRepository : BaseRepository<RecipeTag>, IRecipeTagRepository
{
  private readonly DbSet<RecipeTag> _dbSet;
  public RecipeTagRepository(DataContext context) : base(context)
  {
    _dbSet = context.Set<RecipeTag>();
  }
  public IEnumerable<Recipe> getRecipesByTag(string tagName)
  {
    return _dbSet.Where(x => x.Tag.Name == tagName)
      .Include(x => x.Recipe)
      .Select(x => x.Recipe);
  }
}