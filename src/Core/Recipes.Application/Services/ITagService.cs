using Recipes.Application.Entities;

namespace Recipes.Application.Services;

public interface ITagService
{
  public void AddRange(IEnumerable<Tag> list);
  public IEnumerable<Tag> GetAll();

  void Delete(Guid id);

}