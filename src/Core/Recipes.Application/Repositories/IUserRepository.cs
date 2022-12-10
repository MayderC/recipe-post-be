namespace Recipes.Application.Repositories;

public interface IUserRepository<T> : IRepository<T> where T : class
{
    T GetByUsername(string userame);
    T GetByEmail(string email);
}