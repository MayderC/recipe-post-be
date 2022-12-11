using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Recipes.Application.Entities;

namespace Recipes.WebAPI.Helper;

public class JsonWebToken
{
  private readonly SymmetricSecurityKey _secretKey;
  public JsonWebToken(IConfiguration config)
  {
    var key = config.GetValue<string>("jwt");
    _secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
  }

  public string GetAccessToken(User user)
  {
    var tokenHandler = new JwtSecurityTokenHandler();
    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(new[]
      {
        new Claim(ClaimTypes.Name, user.Username),
      }),
      Expires = DateTime.UtcNow.AddMinutes(60),
      SigningCredentials = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256Signature)
    };
    var token = tokenHandler.CreateToken(tokenDescriptor);
    var tokenString = tokenHandler.WriteToken(token);
    return tokenString;
  }

  public string GetRefreshToken(User user)
  {
    var tokenHandler = new JwtSecurityTokenHandler();
    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(new[]
      {
        new Claim(ClaimTypes.Name, user.Username),
      }),
      Expires = DateTime.UtcNow.AddMinutes(60),
      SigningCredentials = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256Signature)
    };
    var token = tokenHandler.CreateToken(tokenDescriptor);
    var tokenString = tokenHandler.WriteToken(token);
    return tokenString;
  }
}