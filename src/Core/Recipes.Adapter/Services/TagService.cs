using Recipes.Application.Entities;
using Recipes.Application.Repositories;
using Recipes.Application.Services;

namespace Recipes.Adapter.Services;

public class TagService : ITagService
{
  private readonly IRepository<Tag> _tagRepository;
  public TagService(IRepository<Tag> tagRepository)
  {
    _tagRepository = tagRepository;
  }
  
  public void AddRange(IEnumerable<Tag> list)
  {
    _tagRepository.AddRange(list);
  }

  public IEnumerable<Tag> GetAll()
  {
    return _tagRepository.GetAll();
  }

}