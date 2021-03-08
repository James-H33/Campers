using Campers.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Campers.Services.Interfaces
{
  interface ICommentService
  {
    Task<List<Comment>> GetComments(int id);
    Task<Comment> Create(int id, CommentForCreate comment);
  }
}
