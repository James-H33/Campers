using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Campers.Models;
using Campers.Services.Interfaces;

namespace Campers.Services
{
  public class CampgroundService : ICampgroundService
  {

    private IBaseHttp _http;
    public CampgroundService(IBaseHttp http)
    {
      _http = http;
    }

    public async Task<Campground> CreateCampground(Campground newCampground)
    {
      var res = await _http.Post<Campground>("/api/campgrounds", newCampground);
      var createdCampground = Json.Deserialize<Campground>(res.Content);

      return createdCampground;
    }

    public async Task<List<Campground>> GetAll()
    {
      var res = await _http.Get("/api/campgrounds");
      var campgrounds = Json.Deserialize<List<Campground>>(res.Content);

      return campgrounds;
    }

    public async Task<PagedResult<Campground>> Get(PagedQuery query)
    {
      var queryStr = query.AsString();
      var res = await _http.Get($"/api/campgrounds{queryStr}");
      return Json.Deserialize<PagedResult<Campground>>(res.Content);
    }

    public async Task<Campground> GetById(int id)
    {
      var url = $"/api/campgrounds/{id}";
      var res = await _http.Get(url);
      var campground = Json.Deserialize<Campground>(res.Content);

      return campground;
    }
  }
}
