namespace Recipes.Application.Entities;

public interface IRecipeTagService
{
  void Delete(string idTag, string idRecipe);
  void Save(RecipeTag recipeTag);
  void AddRange(List<RecipeTag> list);
  IEnumerable<Recipe> GetRecipesByTag(string tagName);
}