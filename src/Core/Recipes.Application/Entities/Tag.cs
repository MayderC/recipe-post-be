namespace Recipes.Application.Entities;

public class Tag
{
    public  Guid Id { get; set; }
    public string Name { get; set; }
    
    public virtual IEnumerable<RecipeTag> RecipeTags { get; set; }
}