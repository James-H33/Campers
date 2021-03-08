using Blazored.LocalStorage;
using Campers.Models;
using Campers.Services.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Campers.Services
{
  public class UserProfileService : IUserProfileService
  {
    private readonly ILocalStorageService _storage;

    public UserProfileService(ILocalStorageService storage)
    {
      _storage = storage;
    }

    public async Task<UserProfile> GetProfile()
    {
      return await GetProfileFromToken();
    }

    private async Task<UserProfile> GetProfileFromToken()
    {
      var token = await GetToken();

      if (token != null)
      {
        var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);

        var id = jwtToken.Claims.First(c => c.Type == JwtRegisteredClaimNames.NameId);
        var username = jwtToken.Claims.First(c => c.Type == JwtRegisteredClaimNames.UniqueName);

        return new UserProfile
        {
          Id = Int32.Parse(id.Value),
          Username = username.Value
        };
      }
      else
      {
        return new UserProfile();
      }
    }

    private async Task<string> GetToken()
    {
      var token = await _storage.GetItemAsync<string>("access_token");

      if (!String.IsNullOrEmpty(token))
      {
        return token;
      }
      else
      {
        return null;
      }
    }
  }
}
