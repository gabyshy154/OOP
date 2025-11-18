using MeetAgain.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace MeetAgain.Client.Services
{
    public class AvailabilityService
    {
        private readonly HttpClient _http;

        public AvailabilityService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Availability>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<Availability>>("api/availability") ?? new List<Availability>();
        }

        public async Task<Availability?> GetByIdAsync(string id)
        {
            return await _http.GetFromJsonAsync<Availability>($"api/availability/{id}");
        }

        public async Task CreateAsync(Availability availability)
        {
            await _http.PostAsJsonAsync("api/availability", availability);
        }

        public async Task UpdateAsync(Availability availability)
        {
            await _http.PutAsJsonAsync($"api/availability/{availability.Id}", availability);
        }

        public async Task DeleteAsync(string id)
        {
            await _http.DeleteAsync($"api/availability/{id}");
        }
    }
}
