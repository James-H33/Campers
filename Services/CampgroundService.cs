using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Campers.Models;
using Campers.Services.Interfaces;

namespace Campers.Services
{
    public class CampgroundService : ICampgroundService
    {
        
        private IBaseHttp _http;
        private readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public CampgroundService(IBaseHttp http)
        {
            _http = http;
        }

        public async Task<Campground> CreateCampground(Campground newCampground)
        {
            var response = await _http.Post<Campground>("/api/campgrounds", newCampground);
            var createdCampground = JsonSerializer.Deserialize<Campground>(response, jsonOptions);

            return createdCampground;
        }

        public async Task<List<Campground>> GetAll()
        {
            var response = await _http.Get("/api/campgrounds");
            var campgrounds = JsonSerializer.Deserialize<List<Campground>>(response, jsonOptions);

            return campgrounds;
        }

        public async Task<Campground> GetById(int id)
        {
            var url = $"/api/campgrounds/{id}";
            var response = await _http.Get(url);
            var campground = JsonSerializer.Deserialize<Campground>(response, jsonOptions);


            return campground;
        }
    }
}