using Recipes.Application.Entities;

namespace Recipes.Application.Repositories;

public interface IRecipeRepository : IRepository<Recipe>
{
  IEnumerable<Recipe> GetRecipesByUser(Guid id);
}