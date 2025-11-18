using System.Net.Http;
using System.Net.Http.Json;
using MeetAgain.Shared.Models;

namespace MeetAgain.Client.Services
{
    public class MeetupService
    {
        private readonly HttpClient _http;
        private List<Meetup> _cachedMeetups = new();

        public MeetupService(HttpClient http)
        {
            _http = http;
        }

        // ---------- INITIALIZATION ----------
        public async Task InitializeAsync()
        {
            _cachedMeetups = await GetAllMeetupsAsync();
        }

        // ---------- MEETUPS ----------
        public async Task<List<Meetup>> GetAllMeetupsAsync()
        {
            return await _http.GetFromJsonAsync<List<Meetup>>("api/meetups") ?? new();
        }

        public async Task<Meetup?> GetMeetupByIdAsync(string id)
        {
            return await _http.GetFromJsonAsync<Meetup>($"api/meetups/{id}");
        }

        public async Task<Meetup?> AddMeetupAsync(Meetup meetup)
        {
            var response = await _http.PostAsJsonAsync("api/meetups", meetup);
            return await response.Content.ReadFromJsonAsync<Meetup>();
        }

        public async Task UpdateMeetupAsync(Meetup meetup)
        {
            await _http.PutAsJsonAsync($"api/meetups/{meetup.Id}", meetup);
        }

        public async Task DeleteMeetupAsync(string id)
        {
            await _http.DeleteAsync($"api/meetups/{id}");
        }

        // ---------- AVAILABILITIES ----------
        public async Task<List<Availability>> GetAvailabilitiesForMeetupAsync(string meetupId)
        {
            return await _http.GetFromJsonAsync<List<Availability>>(
                $"api/meetups/{meetupId}/availabilities"
            ) ?? new();
        }

        public async Task<Availability?> SetAvailabilityAsync(Availability availability)
        {
            var response = await _http.PostAsJsonAsync("api/availabilities", availability);
            return await response.Content.ReadFromJsonAsync<Availability>();
        }

        // ---------- HELPERS ----------
        public async Task<DateTime?> GetBestDateAsync(string meetupId)
        {
            var availabilities = await GetAvailabilitiesForMeetupAsync(meetupId);

            var best = availabilities
                .Where(a => a.Status == AvailabilityStatus.Available)
                .GroupBy(a => a.ProposedDate)
                .Select(g => new { Date = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .FirstOrDefault();

            return best?.Date;
        }

        public async Task<Dictionary<DateTime, int>> GetAvailabilityCountsByDateAsync(string meetupId)
        {
            var availabilities = await GetAvailabilitiesForMeetupAsync(meetupId);

            return availabilities
                .Where(a => a.Status == AvailabilityStatus.Available)
                .GroupBy(a => a.ProposedDate)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        // ---------- NON-ASYNC ALIASES ----------
        public Task<List<Meetup>> GetAllMeetups() => GetAllMeetupsAsync();
        public Task<Meetup?> GetMeetupById(string id) => GetMeetupByIdAsync(id);
        public Task AddMeetup(Meetup meetup) => AddMeetupAsync(meetup);
        public Task UpdateMeetup(Meetup meetup) => UpdateMeetupAsync(meetup);
    }
}
