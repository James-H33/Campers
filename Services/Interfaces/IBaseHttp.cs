using System.Threading.Tasks;

namespace Campers.Services.Interfaces
{
  public interface IBaseHttp
  {
    Task<string> Get(string path);
    Task<string> Post<T>(string path, T data);
    Task<string> Delete(string path);
  }
}
