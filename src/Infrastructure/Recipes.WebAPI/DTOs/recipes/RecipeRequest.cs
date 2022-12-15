namespace Recipes.WebAPI.DTOs.recipes;

public class RecipeRequest
{
  public string Name { get; set; }
  public Guid UserId { get; set; }
  public string Steps { get; set; }
  public List<Guid> TagIds { get; set; }
  public List<string> TagNames { get; set; }
}