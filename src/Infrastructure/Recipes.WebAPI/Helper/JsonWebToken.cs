using Recipes.Application.Entities;

namespace Recipes.WebAPI.Helper;

public class JsonWebToken
{
    public JsonWebToken()
    {
        
    }

    public string getAccessToken(User user)
    {
        return user.Password + user.Email;
    }

    public string getRefreshToken(User user)
    {
        return user.Email + user.Username;
    }
}