namespace MeetAgain.Models
{
    public class Meetup
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public List<DateTime> ProposedDates { get; set; } = new();
        public DateTime? SelectedDate { get; set; }
        public List<string> ParticipantIds { get; set; } = new();
        public string CreatedBy { get; set; } = string.Empty;
        public MeetupStatus Status { get; set; } = MeetupStatus.Planning;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? GroupId { get; set; }
        public bool NotificationSent { get; set; } = false;
    }

    public enum MeetupStatus
    {
        Planning,
        Scheduled,
        Completed,
        Cancelled
    }
}