using Recipes.Application.Entities;

namespace Recipes.Application.Repositories;

public interface IRecipeTagRepository : IRepository<RecipeTag>
{
  IEnumerable<Recipe> getRecipesByTag(string tagName);
}