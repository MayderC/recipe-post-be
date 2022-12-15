namespace Recipes.Application.Entities;

public class RecipeTag
{
  public  Guid Id { get; set; }
  public Guid TagId {get; set; }
  public Guid RecipeId { get; set; }
  
  public Tag Tag { get; set; }
  public Recipe Recipe { get; set; }
}