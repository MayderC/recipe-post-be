namespace Recipes.WebAPI.DTOs;

public class UserRegisterResponse
{
    public bool RegisterOkey { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken {get; set; }
}