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
    public IBaseHttp _http { get; set; }

    public CommentService(IBaseHttp http)
    {
      _http = http;
    }

    public async Task<List<Comment>> GetComments(int id)
    {
      var res = await _http.Get($"/api/comments/campground/{id}");
      var comments = Json.Deserialize<List<Comment>>(res.Content);

      return comments;
    }

    public async Task<Comment> Create(int id, CommentForCreate comment)
    {
      try
      {
        var url = $"/api/comments/campground/{id}";
        var res = await _http.Post(url, comment);
        var result = Json.Deserialize<Comment>(res.Content);

        return result;
      }
      catch
      {
        return null;
      }
    }
  }
}
