using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeetAgain.Server.Data;
using MeetAgain.Shared.Models;

namespace MeetAgain.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GroupsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FriendGroup>>> GetGroups()
        {
            return await _context.FriendGroups.AsNoTracking().ToListAsync();
        }

        // GET: api/groups/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<FriendGroup>> GetGroup(string id)
        {
            var group = await _context.FriendGroups.FindAsync(id);
            if (group == null) return NotFound();
            return group;
        }

        // POST: api/groups
        [HttpPost]
        public async Task<ActionResult<FriendGroup>> PostGroup(FriendGroup group)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            group.Id = Guid.NewGuid().ToString();
            group.CreatedAt = DateTime.UtcNow;

            _context.FriendGroups.Add(group);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGroup), new { id = group.Id }, group);
        }

        // PUT: api/groups/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup(string id, FriendGroup group)
        {
            if (id != group.Id)
                return BadRequest("Group ID mismatch");

            group.UpdatedAt = DateTime.UtcNow;
            _context.Entry(group).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.FriendGroups.AnyAsync(g => g.Id == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/groups/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(string id)
        {
            var group = await _context.FriendGroups.FindAsync(id);
            if (group == null) return NotFound();

            _context.FriendGroups.Remove(group);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
