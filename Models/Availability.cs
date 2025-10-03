namespace MeetAgain.Models
{
    public class Availability
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string MeetupId { get; set; } = string.Empty;
        public string FriendId { get; set; } = string.Empty;
        public DateTime ProposedDate { get; set; }
        public AvailabilityStatus Status { get; set; } = AvailabilityStatus.NoResponse;
        public string? Note { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

    public enum AvailabilityStatus
    {
        Available,
        Maybe,
        Unavailable,
        NoResponse
    }
}