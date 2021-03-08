using System.Threading.Tasks;
using Campers.Models;

namespace Campers.Services.Interfaces
{
  public interface IAuthService
  {
    Task<LoginResponse> Login(LoginRequest request);
    Task Logout();
  }
}
