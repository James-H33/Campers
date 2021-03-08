using System.Text.Json.Serialization;

namespace Campers.Models
{
  public class ApiResponse
  {
    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("status")]
    public int Status { get; set; }
  }
}
