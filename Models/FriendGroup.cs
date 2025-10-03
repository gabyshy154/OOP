namespace MeetAgain.Models
{
    public class FriendGroup
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> MemberIds { get; set; } = new();
        public string Color { get; set; } = "#6366f1";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}