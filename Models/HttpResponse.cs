using System.Net.Http;

namespace Campers.Models
{
  public class HttpResponse
  {
    public string Content { get; set; }
    public HttpResponseMessage Response { get; set; }
  }
}
