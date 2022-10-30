using System.ComponentModel.DataAnnotations;

namespace Recipes.WebAPI.DTOs;

public class UserRegisterRequest
{ 
    [Required]
    public string Username { get; set; }
    [Required, EmailAddress]
    public string Email { get; set; }
    [Required, MinLength(8)]
    public string Password { get; set; }
    [Required, MinLength(8)]
    public string Repassword { get; set; }
    
}