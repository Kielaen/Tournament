using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tournament.Data;
using Tournament.Models;
using Tournament.ViewModels;

namespace Tournament.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventViewModel>>> GetEvents()
        {
            var events = await _context.Events
                .Include(a => a.Tournament)
                .ToListAsync();

            var data = events.Select(a => new EventViewModel
            {
                 EventID = a.EventID,
                FK_TournamentID = a.FK_TournamentID,
                TournamentName = a?.Tournament?.TournamentName ?? "",
                EventName = a?.EventName ?? "",
                EventNumber = a.EventNumber,
                EventDateTime = a.EventDateTime,
                EventEndDateTime = a.EventEndDateTime,
                EventDateTimeString = a.EventDateTime.ToShortDateString() +" "+a.EventDateTime.ToShortTimeString(),
                EventEndDateTimeString = a.EventEndDateTime.ToShortDateString() + " " + a.EventEndDateTime.ToShortTimeString(),
                AutoClose = a.AutoClose
            });
            return data.ToList();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var @event = await _context.Events.FindAsync(id);

            if (@event == null)
            {
                return NotFound();
            }

            return @event;
        }

        // PUT: api/Events/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event @event)
        {
            if (id != @event.EventID)
            {
                return BadRequest();
            }

            _context.Entry(@event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Events
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event @event)
        {
            var list = _context.Events.ToList();
            @event.EventID = list.Any() ? list.Count() + 1 : 1;
            _context.Events.Add(@event);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Events/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Event>> DeleteEvent(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventID == id);
        }
    }
}
