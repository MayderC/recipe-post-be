using Recipes.Adapter.helpers;
using Recipes.Adapter.Repositories;
using Recipes.Application.Entities;
using Recipes.Application.Repositories;
using Recipes.Application.Services;

namespace Recipes.Adapter.Services;

public class AuthService : IAuthService
{
  private readonly IUserRepository<User> _userRepository;

  public AuthService(IUserRepository<User> userRepository)
  {
    _userRepository = userRepository;
  }

  public User Login(User request)
  {
    var userfound = _userRepository.GetByUsername(request.Username);
    if (HashPassword.Compare(userfound.Password, request.Password)) return userfound;
    throw new Exception("Not Found");
  }

  public User Register(User user)
  {
    user.Id = Guid.NewGuid();
    user.Password = HashPassword.Create(user.Password);
    _userRepository.Save(user);
    return user;
  }
}