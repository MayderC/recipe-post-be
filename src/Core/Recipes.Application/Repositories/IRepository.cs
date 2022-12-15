namespace Recipes.Application.Repositories;
public interface IRepository<T> where T : class
{
    public T Get(Guid id);
    public IEnumerable<T> GetAll();
    public void Delete(T entity);
    public void Update(T entity);
    void Save(T entity);
    void AddRange(IEnumerable<T> list);
}