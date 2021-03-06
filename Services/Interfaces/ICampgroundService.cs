using System.Collections.Generic;
using System.Threading.Tasks;
using Campers.Models;

namespace Campers.Services.Interfaces
{
  public interface ICampgroundService
  {
    Task<List<Campground>> GetAll();
    Task<PagedResult<Campground>> Get(PagedQuery query);
    Task<Campground> GetById(int id);
    Task<Campground> CreateCampground(Campground newCampground);
  }
}
