using Campers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campers.Services.Interfaces
{
    interface ICommentService
    {
        Task<List<Comment>> GetComments(int id);
    }
}
