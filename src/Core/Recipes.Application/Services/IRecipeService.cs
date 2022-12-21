using Recipes.Application.Entities;

namespace Recipes.Application.Services;

public interface IRecipeService
{
  Recipe Save(Recipe request, List<Guid> tagIds, List<string> tagNames);
  IEnumerable<Recipe> GetAll();
  IEnumerable<Recipe> GetRecipesByUser(Guid id);

  IEnumerable<Recipe> getRecipesByTag(string tagName);
}