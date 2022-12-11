using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Recipes.Application.Entities;
using Recipes.Application.Services;
using Recipes.WebAPI.DTOs;
using Recipes.WebAPI.Helper;

namespace Recipes.WebAPI.Controllers;

[ApiController]
[Route("/api/auth")]
public class AuthController : Controller
{
  private readonly IAuthService _authService;
  private readonly IMapper _mapper;
  private readonly IConfiguration _config;
  public AuthController(IAuthService authService, IMapper mapper, IConfiguration config)
  {
    _config = config;
    _mapper = mapper;
    _authService = authService;
  }

  [HttpPost("/register")]
  public ActionResult<UserRegisterResponse> Register([FromBody] UserRegisterRequest request)
  {
    try
    {
      var user = _authService.Register(_mapper.Map<User>(request));
      var token = new JsonWebToken(_config);
      var response = new UserRegisterResponse
      {
        RegisterOkey = true,
        AccessToken = token.GetAccessToken(user),
        RefreshToken = token.GetRefreshToken(user),
      };
      return Ok(response);
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message, "ERROR");
      return BadRequest(400);
    }
  }

  [HttpPost("/login")]
  public ActionResult<UserLoginResponse> Login([FromBody] UserLoginRequest request)
  {
    try
    {
      var user = _authService.Login(_mapper.Map<User>(request));
      var token = new JsonWebToken(_config);
      var loginResponse = new UserLoginResponse
      {
        isAuthenticated = true,
        RefreshToken = token.GetAccessToken(user),
        AccessToken = token.GetRefreshToken(user)
      };
      return Ok(loginResponse);
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
      return BadRequest(e.Message);
    }
  }
}