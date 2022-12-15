namespace Recipes.WebAPI.DTOs;

public class UserLoginResponse
{
    public bool isAuthenticated  {get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}