using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeetAgain.Server.Data;
using MeetAgain.Shared.Models;

namespace MeetAgain.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FriendsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/friends
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Friend>>> GetFriends()
        {
            return await _context.Friends.AsNoTracking().ToListAsync();
        }

        // GET: api/friends/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Friend>> GetFriend(string id)
        {
            var friend = await _context.Friends.FindAsync(id);
            if (friend == null) return NotFound();
            return friend;
        }

        // POST: api/friends
        [HttpPost]
        public async Task<ActionResult<Friend>> PostFriend(Friend friend)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            friend.Id = Guid.NewGuid().ToString();
            friend.CreatedAt = DateTime.UtcNow;

            _context.Friends.Add(friend);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFriend), new { id = friend.Id }, friend);
        }

        // PUT: api/friends/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFriend(string id, Friend friend)
        {
            if (id != friend.Id)
                return BadRequest("Friend ID mismatch");

            friend.UpdatedAt = DateTime.UtcNow;
            _context.Entry(friend).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Friends.AnyAsync(f => f.Id == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/friends/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFriend(string id)
        {
            var friend = await _context.Friends.FindAsync(id);
            if (friend == null) return NotFound();

            _context.Friends.Remove(friend);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
