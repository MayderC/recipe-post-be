using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.Application.Entities;

public class Recipe
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid LocationId { get; set; }
    public User User { get; set; } = new User();

    [ForeignKey("LocationId")]
    public LookUpItem Location { get; set; } = new LookUpItem();
    public string Name { get; set; } = "";
    public virtual IEnumerable<RecipeTag> RecipeTags { get; set; } = new List<RecipeTag>();
    public virtual IEnumerable<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}