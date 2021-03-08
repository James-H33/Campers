using System.Text.Json;

namespace Campers.Models
{
  public class Json
  {
    private static readonly JsonSerializerOptions options = new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true,
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public static T Deserialize<T>(string data)
    {
      return JsonSerializer.Deserialize<T>(data, options);
    }
  }
}
