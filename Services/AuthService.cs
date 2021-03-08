using System.Threading.Tasks;
using Blazored.LocalStorage;
using Campers.Models;
using Campers.Services.Interfaces;

namespace Campers.Services
{
  public class AuthService : IAuthService
  {
    private readonly IBaseHttp _http;
    private readonly ILocalStorageService _storage;
    private string AccessToken = "access_token";

    public AuthService(IBaseHttp http, ILocalStorageService storage)
    {
      _http = http;
      _storage = storage;
    }

    public async Task<LoginResponse> Login(LoginRequest request)
    {
      try
      {
        var response = await _http.Post("/api/tokens", request);
        var loginResponse = Json.Deserialize<LoginResponse>(response.Content);
        await StoreAuthToken(loginResponse);

        return loginResponse;
      }
      catch
      {
        return new LoginResponse();
      }
    }

    public async Task Logout()
    {
      await _storage.RemoveItemAsync("access_token");
    }

    private async Task StoreAuthToken(LoginResponse response)
    {
      await _storage.SetItemAsync(AccessToken, response.AccessToken);
    }
  }
}
