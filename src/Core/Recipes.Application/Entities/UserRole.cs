namespace Recipes.Application.Entities;

public class UserRole
{
  public Guid Id { get; set; }
  public Guid UserId { get; set; }
  public Guid RoleId { get; set; }
  
  //properties navegations
  public User Users { get; set; }
  public Role Roles { get; set; }
}