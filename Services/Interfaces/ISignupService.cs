using System.Threading.Tasks;
using Campers.Models;

namespace Campers.Services.Interfaces
{
  public interface ISignupService
  {
    Task<HttpResponse> Signup(SignupRequest model);
  }
}
