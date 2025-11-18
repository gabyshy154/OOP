using MeetAgain.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace MeetAgain.Client.Services
{
    public class FriendGroupService
    {
        private readonly HttpClient _http;

        public FriendGroupService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<FriendGroup>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<FriendGroup>>("api/friendgroups") ?? new List<FriendGroup>();
        }

        public async Task<FriendGroup?> GetByIdAsync(string id)
        {
            return await _http.GetFromJsonAsync<FriendGroup>($"api/friendgroups/{id}");
        }

        public async Task CreateAsync(FriendGroup group)
        {
            await _http.PostAsJsonAsync("api/friendgroups", group);
        }

        public async Task UpdateAsync(FriendGroup group)
        {
            await _http.PutAsJsonAsync($"api/friendgroups/{group.Id}", group);
        }

        public async Task DeleteAsync(string id)
        {
            await _http.DeleteAsync($"api/friendgroups/{id}");
        }
    }
}
