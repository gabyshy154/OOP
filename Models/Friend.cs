namespace MeetAgain.Models
{
    public class Friend
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public List<string> GroupIds { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}