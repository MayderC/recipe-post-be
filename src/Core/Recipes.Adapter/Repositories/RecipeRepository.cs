using Microsoft.EntityFrameworkCore;
using Recipes.Application.Entities;
using Recipes.Application.Repositories;
using Recipes.Database.Data;

namespace Recipes.Adapter.Repositories;

public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
{

  private readonly DbSet<Recipe> _dbSet;
  public RecipeRepository(DataContext context) : base(context)
  {
    _dbSet = context.Set<Recipe>();
  }
  public IEnumerable<Recipe> GetRecipesByUser(Guid id)
  {
    return _dbSet.Where(x => x.User.Id.Equals(id));
  }
}