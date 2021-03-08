using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Campers.Models;
using Campers.Services.Interfaces;

namespace Campers.Services
{
  public class BaseHttp : IBaseHttp
  {
    private HttpClient _http;
    private string servicesUrl = "https://localhost:6001";
    private readonly ILocalStorageService _storage;

    public BaseHttp(HttpClient http, ILocalStorageService storage)
    {
      _http = http;
      _storage = storage;
    }

    public async Task<HttpResponse> Get(string path)
    {
      var token = await GetAuthToken();
      _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

      var response = await _http.GetAsync(new Uri($"{servicesUrl}{path}"));
      var content = await response.Content.ReadAsStringAsync();

      return new HttpResponse
      {
        Content = content,
        Response = response
      };
    }

    public async Task<HttpResponse> Post<T>(string path, T data)
    {
      var token = await GetAuthToken();
      _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

      var response = await _http.PostAsJsonAsync(new Uri($"{servicesUrl}{path}"), data);
      var content = await response.Content.ReadAsStringAsync();

      return new HttpResponse
      {
        Content = content,
        Response = response
      };
    }

    public async Task<HttpResponse> Delete(string path)
    {
      var token = await GetAuthToken();
      _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

      var response = await _http.DeleteAsync(new Uri($"{servicesUrl}{path}"));
      var content = await response.Content.ReadAsStringAsync();

      return new HttpResponse
      {
        Content = content,
        Response = response
      };
    }

    private async Task<string> GetAuthToken()
    {
      return await _storage.GetItemAsync<string>("access_token");
    }
  }
}
