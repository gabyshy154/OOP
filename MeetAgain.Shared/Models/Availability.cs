namespace MeetAgain.Shared.Models
{
    public class Availability
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string MeetupId { get; set; } = string.Empty;
        public string FriendId { get; set; } = string.Empty;
        public DateTime ProposedDate { get; set; }
        public AvailabilityStatus Status { get; set; } = AvailabilityStatus.NoResponse;
        public string? Note { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;   // ✅ Added for consistency
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;   // ✅ Keeps timestamps uniform
    }

    public enum AvailabilityStatus
    {
        Available,
        Maybe,
        Unavailable,
        NoResponse
    }
}
