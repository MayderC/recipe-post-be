using Recipes.Application.Entities;
using Recipes.Application.Repositories;

namespace Recipes.Adapter.Services;

public class RecipeTagService : IRecipeTagService
{
  private readonly IRepository<RecipeTag> _recipeTagRepository;
  public RecipeTagService(IRepository<RecipeTag> recipeTagRepository)
  {
    _recipeTagRepository = recipeTagRepository;
  }
  
  public void Delete(string idTag, string idRecipe)
  {
    throw new NotImplementedException();
  }
  public void Save(RecipeTag recipeTag)
  {
    throw new NotImplementedException();
  }
  public void AddRange(List<RecipeTag> list)
  {
     _recipeTagRepository.AddRange(list);
  }
}