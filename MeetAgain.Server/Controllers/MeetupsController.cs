using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeetAgain.Server.Data;
using MeetAgain.Shared.Models;

namespace MeetAgain.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetupsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MeetupsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/meetups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meetup>>> GetMeetups()
        {
            return await _context.Meetups
                .AsNoTracking()
                .OrderByDescending(m => m.CreatedAt)
                .ToListAsync();
        }

        // GET: api/meetups/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Meetup>> GetMeetup(string id)
        {
            var meetup = await _context.Meetups.FindAsync(id);
            if (meetup == null) return NotFound();
            return meetup;
        }

        // GET: api/meetups/{id}/availabilities
        [HttpGet("{id}/availabilities")]
        public async Task<ActionResult<IEnumerable<Availability>>> GetAvailabilities(string id)
        {
            return await _context.Availabilities
                .Where(a => a.MeetupId == id)
                .AsNoTracking()
                .ToListAsync();
        }

        // POST: api/meetups
        [HttpPost]
        public async Task<ActionResult<Meetup>> PostMeetup(Meetup meetup)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            meetup.Id = Guid.NewGuid().ToString();
            meetup.CreatedAt = DateTime.UtcNow;
            meetup.UpdatedAt = DateTime.UtcNow; // FIX #1

            // FIX #2 — Make sure lists are not null
            meetup.ProposedDates ??= new List<DateTime>();
            meetup.ParticipantIds ??= new List<string>();

            _context.Meetups.Add(meetup);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMeetup), new { id = meetup.Id }, meetup);
        }

        // PUT: api/meetups/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeetup(string id, Meetup meetup)
        {
            if (id != meetup.Id)
                return BadRequest("Meetup ID mismatch");

            meetup.UpdatedAt = DateTime.UtcNow; // FIX #3

            _context.Entry(meetup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Meetups.AnyAsync(m => m.Id == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/meetups/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeetup(string id)
        {
            var meetup = await _context.Meetups.FindAsync(id);
            if (meetup == null) return NotFound();

            var availabilities = await _context.Availabilities
                .Where(a => a.MeetupId == id)
                .ToListAsync();

            _context.Availabilities.RemoveRange(availabilities);
            _context.Meetups.Remove(meetup);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
