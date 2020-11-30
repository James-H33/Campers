using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;
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

    public async Task<string> Get(string path)
    {
      var token = await GetAuthToken();
      _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

      var response = await _http.GetAsync($"{servicesUrl}{path}");
      return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> Post<T>(string path, T data)
    {
      // var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
      // var payload = JsonConvert.SerializeObject(data, settings);
      // var content = new StringContent(payload, Encoding.UTF8, "application/json");
      var token = await GetAuthToken();
      _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

      var response = await _http.PostAsJsonAsync($"{servicesUrl}{path}", data);
      return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> Delete(string path)
    {
      var token = await GetAuthToken();
      _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

      var response = await _http.DeleteAsync($"{servicesUrl}{path}");
      return await response.Content.ReadAsStringAsync();
    }

    private async Task<string> GetAuthToken()
    {
      return await _storage.GetItemAsync<string>("access_token");
    }
  }
}