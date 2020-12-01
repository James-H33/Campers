using System.Threading.Tasks;
using Campers.Models;

namespace Campers.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<LoginResponse> Login(LoginRequest request);
        public Task Logout();
    }
}