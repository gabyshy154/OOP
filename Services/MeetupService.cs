using MeetAgain.Models;

namespace MeetAgain.Services
{
    public class MeetupService
    {
        private readonly List<Meetup> _meetups = new();
        private readonly List<Availability> _availabilities = new();

        public MeetupService()
        {
            InitializeSampleData();
        }

        private void InitializeSampleData()
        {
            var meetup1 = new Meetup
            {
                Id = "m1",
                Title = "Team Lunch",
                Description = "Monthly team lunch at downtown",
                Location = "Italian Restaurant",
                ProposedDates = new List<DateTime>
                {
                    DateTime.Now.AddDays(7),
                    DateTime.Now.AddDays(8),
                    DateTime.Now.AddDays(9)
                },
                ParticipantIds = new List<string> { "1", "2", "3" },
                Status = MeetupStatus.Planning,
                GroupId = "g1"
            };

            _meetups.Add(meetup1);
        }

        // Return all meetups safely
        public List<Meetup> GetAllMeetups() => _meetups ?? new List<Meetup>();

        // Get a meetup by Id safely
        public Meetup? GetMeetupById(string id) => _meetups?.FirstOrDefault(m => m.Id == id);

        // Add a new meetup
        public void AddMeetup(Meetup meetup)
        {
            if (meetup == null) return;

            // Assign new Id if not set
            if (string.IsNullOrEmpty(meetup.Id))
                meetup.Id = Guid.NewGuid().ToString();

            meetup.ProposedDates ??= new List<DateTime>();
            meetup.ParticipantIds ??= new List<string>();

            _meetups.Add(meetup);
        }

        // Update existing meetup safely
        public void UpdateMeetup(Meetup meetup)
        {
            if (meetup == null) return;

            var index = _meetups.FindIndex(m => m.Id == meetup.Id);
            if (index >= 0)
            {
                meetup.ProposedDates ??= new List<DateTime>();
                meetup.ParticipantIds ??= new List<string>();
                _meetups[index] = meetup;
            }
        }

        // Delete meetup and its availabilities
        public void DeleteMeetup(string id)
        {
            if (string.IsNullOrEmpty(id)) return;

            _meetups.RemoveAll(m => m.Id == id);
            _availabilities.RemoveAll(a => a.MeetupId == id);
        }

        // Set availability safely
        public void SetAvailability(Availability availability)
        {
            if (availability == null) return;

            var existing = _availabilities.FirstOrDefault(a =>
                a.MeetupId == availability.MeetupId &&
                a.FriendId == availability.FriendId &&
                a.ProposedDate == availability.ProposedDate);

            if (existing != null)
            {
                existing.Status = availability.Status;
                existing.Note = availability.Note;
                existing.UpdatedAt = DateTime.Now;
            }
            else
            {
                availability.UpdatedAt = DateTime.Now;
                _availabilities.Add(availability);
            }
        }

        // Get availabilities safely
        public List<Availability> GetAvailabilitiesForMeetup(string meetupId)
        {
            if (string.IsNullOrEmpty(meetupId)) return new List<Availability>();

            return _availabilities
                .Where(a => a.MeetupId == meetupId)
                .ToList();
        }

        // Count availability by date
        public Dictionary<DateTime, int> GetAvailabilityCountsByDate(string meetupId)
        {
            var availabilities = GetAvailabilitiesForMeetup(meetupId);
            return availabilities
                .Where(a => a.Status == AvailabilityStatus.Available)
                .GroupBy(a => a.ProposedDate)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        // Get best date based on availability
        public DateTime? GetBestDate(string meetupId)
        {
            var counts = GetAvailabilityCountsByDate(meetupId);
            return counts.Any() ? counts.OrderByDescending(kvp => kvp.Value).First().Key : null;
        }
    }
}
