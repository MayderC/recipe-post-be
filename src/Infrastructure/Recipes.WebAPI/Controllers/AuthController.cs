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
    
    public AuthController(IAuthService authService, IMapper mapper)
    {
        _mapper = mapper;
        _authService = authService;
    }
    
    [HttpPost("/register")]
    public ActionResult<UserRegisterResponse> Register([FromBody] UserRegisterRequest request)
    {
        try
        {
            var user = _authService.Register(_mapper.Map<User>(request));
            var token = new JsonWebToken();
            var response = new UserRegisterResponse
            {
                AccessToken = token.getAccessToken(user),
                RefreshToken = token.getRefreshToken(user),
            };
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return BadRequest(400);
        }
    }

    [HttpPost("/login")]
    public ActionResult<UserLoginResponse> Login([FromBody] UserLoginRequest user)
    {
        var toUser = new User
        {
            Password = user.password,
            Username = user.Username
        };

        var users = _authService.Login(toUser); 
        
        UserLoginResponse loginResponse = new UserLoginResponse
        {
            isAuthenticated = true,
            RefreshToken = "refresh",
            AccessToken = "access"
        };
        return loginResponse;
    }
}