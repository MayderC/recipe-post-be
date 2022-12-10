using Microsoft.EntityFrameworkCore;
using Recipes.Application.Entities;
using Recipes.Application.Repositories;
using Recipes.Database.Data;

namespace Recipes.Adapter.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository<User>
{
  private readonly DbSet<User> _dbSet;
  public UserRepository(DataContext context) : base(context)
  {
    _dbSet = context.Set<User>();
  }
  public User GetByUsername(string userame)
  {
    var user = _dbSet.FirstOrDefault(user => user.Username == userame);
    if (user == null) throw new Exception("Not Found");
    return user;
  }
  
  public User GetByEmail(string email)
  {
    var user = _dbSet.FirstOrDefault(user => user.Email == email);
    if (user == null) throw new Exception("Not Found");
    return user;
  }

}