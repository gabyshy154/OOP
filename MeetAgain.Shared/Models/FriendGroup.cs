namespace MeetAgain.Shared.Models
{
    public class FriendGroup
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> MemberIds { get; set; } = new();
        public string Color { get; set; } = "#6366f1"; // Default Tailwind Indigo-500
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;  // ✅ Added
    }
}
