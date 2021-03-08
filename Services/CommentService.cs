using Campers.Models;
using Campers.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Campers.Services
{
  public class CommentService : ICommentService
  {
    public HttpClient _http { get; set; }

    public CommentService(HttpClient http)
    {
      _http = http;
    }

    public async Task<List<Comment>> GetComments(int id)
    {
      var comments = await _http.GetFromJsonAsync<List<Comment>>($"https://localhost:6001/api/comments/campground/{id}");

      return comments;
    }

    public async Task<Comment> Create(int id, CommentForCreate comment)
    {
      try
      {
        var url = $"https://localhost:6001/api/comments/campground/{id}";
        var response = await _http.PostAsJsonAsync<CommentForCreate>(url, comment);
        var result = await response.Content.ReadFromJsonAsync<Comment>();

        return result;
      }
      catch
      {
        return null;
      }
    }
  }
}
