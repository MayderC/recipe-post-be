using Recipes.Adapter.Repositories;
using Recipes.Application.Entities;
using Recipes.Application.Repositories;
using Recipes.Application.Services;

namespace Recipes.Adapter.Services;

public class AuthService : IAuthService
{
    private readonly IRepository<User> _userRepository;

    public AuthService(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }
    
    public User Login(User user)
    {
        return  _userRepository.Get(user.Id);
    }

    public User Register(User user)
    {
        user.Id = Guid.NewGuid();
         _userRepository.Save(user);
         return user;
    }
}