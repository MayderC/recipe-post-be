using Microsoft.EntityFrameworkCore;
using Recipes.Application.Repositories;
using Recipes.Database.Data;

namespace Recipes.Adapter.Repositories;

public class BaseRepository<T> : IRepository<T> where T : class
{
    private readonly DataContext _context;
    private readonly DbSet<T> _dbSet;
    public BaseRepository(DataContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    public void AddRange(IEnumerable<T> list)
    {
        _dbSet.AddRange(list);
        _context.SaveChanges();
    }
    public T Get(Guid id)
    {
        var entity = _dbSet.Find(id);
        if (entity == null) throw new Exception("not found");
        return entity;
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
        _context.SaveChanges(true);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges(true);
    }
    public void Save(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges(true);
    }
}