﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Recipes.WebAPI.DTOs.recipes;
using Recipes.Application.Entities;
using Recipes.Application.Services;

namespace Recipes.WebAPI.Controllers;

[Route("api/recipes")]
[ApiController]
public class RecipeController : Controller
{
  private readonly IMapper _mapper;
  private readonly IRecipeService _recipeService;
  
  public RecipeController(IRecipeService recipeService,IMapper mapper)
  {
    _mapper = mapper;
    _recipeService = recipeService;
  }

  [HttpPost]
  public ActionResult SaveRecipe(RecipeRequest request)
  {
    try
    {
      var recipe = _mapper.Map<Recipe>(request);
      var recipeResponse = _recipeService.Save(recipe, request.TagIds, request.TagNames);
      var res = _mapper.Map<RecipeResponse>(recipeResponse);
      return Ok(res);
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
      return  BadRequest();
    }
  }
  [HttpGet]
  public ActionResult<RecipeResponse> GetRecipes()
  {
    var recipes = _recipeService.GetAll();
    return Ok(recipes);
  }
  [HttpGet("user/{id}")]
  public ActionResult<List<RecipeResponse>> GetRecipesByUser(string id)
  {
    return Ok(id);
  }
}