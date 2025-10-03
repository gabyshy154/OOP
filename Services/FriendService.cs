using MeetAgain.Models;

namespace MeetAgain.Services
{
    public class FriendService
    {
        private readonly List<Friend> _friends = new();
        private readonly List<FriendGroup> _groups = new();

        public FriendService()
        {
            InitializeSampleData();
        }

        private void InitializeSampleData()
        {
            _friends.AddRange(new List<Friend>
            {
                new Friend { Id = "1", Name = "Alice Johnson", Email = "alice@example.com", Avatar = "AJ" },
                new Friend { Id = "2", Name = "Bob Smith", Email = "bob@example.com", Avatar = "BS" },
                new Friend { Id = "3", Name = "Carol White", Email = "carol@example.com", Avatar = "CW" },
                new Friend { Id = "4", Name = "David Brown", Email = "david@example.com", Avatar = "DB" },
                new Friend { Id = "5", Name = "Emma Davis", Email = "emma@example.com", Avatar = "ED" }
            });

            _groups.AddRange(new List<FriendGroup>
            {
                new FriendGroup 
                { 
                    Id = "g1", 
                    Name = "Work Team", 
                    Description = "Office colleagues",
                    MemberIds = new List<string> { "1", "2", "3" },
                    Color = "#6366f1"
                },
                new FriendGroup 
                { 
                    Id = "g2", 
                    Name = "College Friends", 
                    Description = "University buddies",
                    MemberIds = new List<string> { "2", "4", "5" },
                    Color = "#10b981"
                }
            });
        }

        // Return all friends safely
        public List<Friend> GetAllFriends() => _friends ?? new List<Friend>();

        // Get friend by Id safely
        public Friend? GetFriendById(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;
            return _friends.FirstOrDefault(f => f.Id == id);
        }

        // Add a new friend safely
        public void AddFriend(Friend friend)
        {
            if (friend == null) return;
            if (string.IsNullOrEmpty(friend.Id))
                friend.Id = Guid.NewGuid().ToString();

            _friends.Add(friend);
        }

        // Update friend safely
        public void UpdateFriend(Friend friend)
        {
            if (friend == null) return;

            var index = _friends.FindIndex(f => f.Id == friend.Id);
            if (index >= 0)
            {
                _friends[index] = friend;
            }
        }

        // Delete friend safely
        public void DeleteFriend(string id)
        {
            if (string.IsNullOrEmpty(id)) return;
            _friends.RemoveAll(f => f.Id == id);
        }

        // Return all groups safely
        public List<FriendGroup> GetAllGroups() => _groups ?? new List<FriendGroup>();

        // Get group by Id safely
        public FriendGroup? GetGroupById(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;
            return _groups.FirstOrDefault(g => g.Id == id);
        }

        // Add a new group safely
        public void AddGroup(FriendGroup group)
        {
            if (group == null) return;
            if (string.IsNullOrEmpty(group.Id))
                group.Id = Guid.NewGuid().ToString();

            group.MemberIds ??= new List<string>();
            _groups.Add(group);
        }

        // Update group safely
        public void UpdateGroup(FriendGroup group)
        {
            if (group == null) return;

            var index = _groups.FindIndex(g => g.Id == group.Id);
            if (index >= 0)
            {
                group.MemberIds ??= new List<string>();
                _groups[index] = group;
            }
        }

        // Delete group safely
        public void DeleteGroup(string id)
        {
            if (string.IsNullOrEmpty(id)) return;
            _groups.RemoveAll(g => g.Id == id);
        }

        // Get multiple friends by IDs safely
        public List<Friend> GetFriendsByIds(List<string> ids)
        {
            if (ids == null || !ids.Any()) return new List<Friend>();
            return _friends.Where(f => ids.Contains(f.Id)).ToList();
        }
    }
}
