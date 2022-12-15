using Recipes.Application.Entities;
using Recipes.Application.Repositories;
using Recipes.Application.Services;

namespace Recipes.Adapter.Services;

public class RecipeService : IRecipeService
{

  private readonly IRepository<Recipe> _recipeRepository;
  private readonly ITagService _tagService;
  private readonly IRecipeTagService _recipeTagService;
  
  public RecipeService(IRepository<Recipe> recipeRepository, ITagService tagService, IRecipeTagService recipeTagService)
  {
    _recipeTagService = recipeTagService;
    _recipeRepository = recipeRepository;
    _tagService = tagService;
  }
  
  /*
   * this method, receive the recipe and tagsId which are saved in the DB
   * also receive a list of names which are not save in the db
   * we ned generate a guid id for these tags and save in the db, then
   * concatenate to tagsId and finaly insert in the pivot table RecipeTag
   */
  public Recipe Save(Recipe request, List<Guid> tagIds, List<string> tagNames)
  {
    request.Id = Guid.NewGuid();
    _recipeRepository.Save(request);
    
    var listTag = new List<Tag>();
    if (tagNames.Count > 0)
    {
      foreach (var name in tagNames)
        listTag.Add(new Tag {Id = Guid.NewGuid(), Name = name});
      _tagService.AddRange(listTag);
    }
    var idSaveds = listTag.Select(x => x.Id).ToList();
    tagIds.AddRange(idSaveds);

    if (idSaveds.Count > 0)
    {
      var recipeTagList = tagIds.Select(id => new RecipeTag
          {
            Id = Guid.NewGuid(), 
            RecipeId = request.Id, 
            TagId = id
          })
        .ToList();
      _recipeTagService.AddRange(recipeTagList);
    }
    
    return request;
  }
  public IEnumerable<Recipe> GetAll()
  {
    return _recipeRepository.GetAll();
  }

}