using Recipes.Application.Entities;

namespace Recipes.Application.Services;

public interface IAuthService
{
    User Login(User user);
    User Register(User user);
}