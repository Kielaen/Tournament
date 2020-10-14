using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tournament.Data;
using Tournament.Models;

namespace Tournament.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventDetailStatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventDetailStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EventDetailStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDetailStatus>>> GetEventDetailStatuses()
        {
            return await _context.EventDetailStatuses.ToListAsync();
        }

        // GET: api/EventDetailStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventDetailStatus>> GetEventDetailStatus(int id)
        {
            var eventDetailStatus = await _context.EventDetailStatuses.FindAsync(id);

            if (eventDetailStatus == null)
            {
                return NotFound();
            }

            return eventDetailStatus;
        }

        // PUT: api/EventDetailStatus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventDetailStatus(int id, EventDetailStatus eventDetailStatus)
        {
            if (id != eventDetailStatus.EventDetailStatusID)
            {
                return BadRequest();
            }

            _context.Entry(eventDetailStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventDetailStatusExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Update Successful");
        }

        // POST: api/EventDetailStatus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EventDetailStatus>> PostEventDetailStatus(EventDetailStatus eventDetailStatus)
        {
            _context.EventDetailStatuses.Add(eventDetailStatus);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/EventDetailStatus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventDetailStatus>> DeleteEventDetailStatus(int id)
        {
            var eventDetailStatus = await _context.EventDetailStatuses.FindAsync(id);
            if (eventDetailStatus == null)
            {
                return NotFound();
            }

            _context.EventDetailStatuses.Remove(eventDetailStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventDetailStatusExists(int id)
        {
            return _context.EventDetailStatuses.Any(e => e.EventDetailStatusID == id);
        }
    }
}
