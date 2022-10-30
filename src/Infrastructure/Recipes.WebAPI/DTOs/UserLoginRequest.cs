using System.ComponentModel.DataAnnotations;

namespace Recipes.WebAPI.DTOs;

public class UserLoginRequest
{
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string password { get; set; }
}