using System.Threading.Tasks;
using Campers.Models;

namespace Campers.Services.Interfaces
{
  public interface IBaseHttp
  {
    Task<HttpResponse> Get(string path);
    Task<HttpResponse> Post<T>(string path, T data);
    Task<HttpResponse> Delete(string path);
  }
}
