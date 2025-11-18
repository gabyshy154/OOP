using System.Net.Http;
using System.Net.Http.Json;
using MeetAgain.Shared.Models;

namespace MeetAgain.Client.Services
{
    public class FriendService
    {
        private readonly HttpClient _http;
        private List<Friend> _cachedFriends = new();
        private List<FriendGroup> _cachedGroups = new();

        public FriendService(HttpClient http)
        {
            _http = http;
        }

        // ---------- INITIALIZATION ----------
        public async Task InitializeAsync()
        {
            _cachedFriends = await GetAllFriendsAsync();
            _cachedGroups = await GetAllGroupsAsync();
        }

        // ---------- FRIENDS ----------
        public async Task<List<Friend>> GetAllFriendsAsync()
        {
            return await _http.GetFromJsonAsync<List<Friend>>("api/friends") ?? new();
        }

        public async Task<Friend?> GetFriendByIdAsync(string id)
        {
            return await _http.GetFromJsonAsync<Friend>($"api/friends/{id}");
        }

        public async Task<Friend?> AddFriendAsync(Friend friend)
        {
            var response = await _http.PostAsJsonAsync("api/friends", friend);
            return await response.Content.ReadFromJsonAsync<Friend>();
        }

        public async Task UpdateFriendAsync(Friend friend)
        {
            await _http.PutAsJsonAsync($"api/friends/{friend.Id}", friend);
        }

        public async Task DeleteFriendAsync(string id)
        {
            await _http.DeleteAsync($"api/friends/{id}");
        }

        // ---------- GROUPS ----------
        public async Task<List<FriendGroup>> GetAllGroupsAsync()
        {
            return await _http.GetFromJsonAsync<List<FriendGroup>>("api/groups") ?? new();
        }

        public async Task<FriendGroup?> GetGroupByIdAsync(string id)
        {
            return await _http.GetFromJsonAsync<FriendGroup>($"api/groups/{id}");
        }

        public async Task<List<Friend>> GetFriendsByIdsAsync(List<string> ids)
        {
            var all = await GetAllFriendsAsync();
            return all.Where(f => ids.Contains(f.Id)).ToList();
        }

        // ---------- NON-ASYNC ALIASES ----------
        public Task<List<Friend>> GetAllFriends() => GetAllFriendsAsync();
        public Task<Friend?> GetFriendById(string id) => GetFriendByIdAsync(id);
        public Task<List<FriendGroup>> GetAllGroups() => GetAllGroupsAsync();
        public Task<FriendGroup?> GetGroupById(string id) => GetGroupByIdAsync(id);
        public Task<List<Friend>> GetFriendsByIds(List<string> ids) => GetFriendsByIdsAsync(ids);
    }
}
