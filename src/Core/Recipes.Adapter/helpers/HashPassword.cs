
using System.Security.Cryptography;
using System.Text;

namespace Recipes.Adapter.helpers;
public class HashPassword
{

  public static string Create(string password)
  {
    var sha256 = SHA256.Create();
    var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
    return Convert.ToBase64String(hash);
  }

  public static bool Compare(string hashPassword, string planePassword)
  {
    var sha256 = SHA256.Create();
    var newHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(planePassword));
    return newHash.SequenceEqual(Convert.FromBase64String(hashPassword));
  }
}