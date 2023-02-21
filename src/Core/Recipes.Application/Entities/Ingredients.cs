namespace Recipes.Application.Entities;

public class Ingredient
{
  public Guid Id { get; set; }
  public Guid ProductId { get; set; }
  public Guid SizeId { get; set; }
  public float Quantity { get; set; }
  
  public LookUpItem Product { get; set; }
  public LookUpItem Size { get; set; }
}