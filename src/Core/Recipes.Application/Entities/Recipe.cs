namespace Recipes.Application.Entities;

public class Recipe
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Steps { get; set; }
    public IEnumerable<Tag> Tags { get; set; }
    
}