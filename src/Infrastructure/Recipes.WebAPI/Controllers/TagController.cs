using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Recipes.Application.Entities;
using Recipes.Application.Services;
using Recipes.WebAPI.DTOs.tag;

namespace Recipes.WebAPI.Controllers;

[ApiController]
[Route("api/recipes/tags")]
public class TagController : Controller
{
  private IRecipeTagService _recipeTagService;
  
    public TagController(IRecipeTagService recipeTagService)
    {
      _recipeTagService = recipeTagService;
    }

  [HttpGet]
  public ActionResult<TagResponse> GetTags(string name)
  {
    //var response = _recipeTagService.
    return Ok(name);
  }
}