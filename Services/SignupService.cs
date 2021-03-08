using System;
using System.Text.Json;
using System.Threading.Tasks;
using Campers.Models;
using Campers.Services.Interfaces;

namespace Campers.Services
{
  public class SignupService : ISignupService
  {

    private IBaseHttp _http;

    public SignupService(IBaseHttp http)
    {
      _http = http;
    }

    public async Task<HttpResponse> Signup(SignupRequest model)
    {
      try
      {
        return await _http.Post("/api/signup", model);
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error has occurred.");
        return null;
      }
    }
  }
}
