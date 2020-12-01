using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Campers.Models;
using Campers.Services.Interfaces;

namespace Campers.Services
{
    public class CampgroundService : ICampgroundService
    {
        private HttpClient _http;

        public CampgroundService(HttpClient http)
        {
            _http = http;
        }

        public async Task<Campground> CreateCampground(Campground newCampground)
        {
            var response = await _http.PostAsJsonAsync<Campground>("https://localhost:6001/api/campgrounds", newCampground);
            var createdCampground = await response.Content.ReadFromJsonAsync<Campground>();

            return createdCampground;
        }

        public async Task<List<Campground>> GetAll()
        {
            var campgrounds = await _http.GetFromJsonAsync<List<Campground>>("https://localhost:6001/api/campgrounds");

            return campgrounds;
        }

        public async Task<Campground> GetById(int id)
        {
            var url = $"https://localhost:6001/api/campgrounds/{id}";
            var campground = await _http.GetFromJsonAsync<Campground>(url);

            return campground;
        }
    }
}