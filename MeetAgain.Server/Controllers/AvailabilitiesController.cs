using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeetAgain.Server.Data;
using MeetAgain.Shared.Models;

namespace MeetAgain.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilitiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AvailabilitiesController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ GET: api/availabilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Availability>>> GetAvailabilities()
        {
            return await _context.Availabilities
                .AsNoTracking()
                .ToListAsync();
        }

        // ✅ GET: api/availabilities/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Availability>> GetAvailability(string id)
        {
            var availability = await _context.Availabilities.FindAsync(id);
            if (availability == null)
                return NotFound();
            return availability;
        }

        // POST: api/availabilities
        [HttpPost]
        public async Task<ActionResult<Availability>> PostAvailability(Availability availability)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            availability.Id = Guid.NewGuid().ToString();
            availability.CreatedAt = DateTime.UtcNow;
            availability.UpdatedAt = DateTime.UtcNow;

            _context.Availabilities.Add(availability);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAvailability), new { id = availability.Id }, availability);
        }

        // PUT: api/availabilities/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvailability(string id, Availability availability)
        {
            if (id != availability.Id)
                return BadRequest("Availability ID mismatch");

            var existing = await _context.Availabilities.FindAsync(id);
            if (existing == null)
                return NotFound();

            availability.UpdatedAt = DateTime.UtcNow;
            _context.Entry(existing).CurrentValues.SetValues(availability);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // ✅ DELETE: api/availabilities/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvailability(string id)
        {
            var availability = await _context.Availabilities.FindAsync(id);
            if (availability == null)
                return NotFound();

            _context.Availabilities.Remove(availability);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
