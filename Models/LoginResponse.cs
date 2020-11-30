

using System.Text.Json.Serialization;

namespace Campers.Models
{
    public class LoginResponse
    {
        [JsonPropertyNameAttribute("access_token")]
        public string AccessToken { get; set; }
    }
}