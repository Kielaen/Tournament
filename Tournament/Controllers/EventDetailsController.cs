using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class EventDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly HolloywoodService _service;

        public EventDetailsController(ApplicationDbContext context, HolloywoodService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/EventDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDetailViewModel>>> GetEventDetails()
        {
            var details = await _service.GetEventDetails();
            return details;
            //return await _context.EventDetails.ToListAsync();
        }

        // GET: api/EventDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventDetail>> GetEventDetail(int id)
        {
            var eventDetail = await _context.EventDetails.FindAsync(id);

            if (eventDetail == null)
            {
                return NotFound();
            }

            return eventDetail;
        }

        // PUT: api/EventDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventDetail(int id, EventDetail eventDetail)
        {
            if (id != eventDetail.EventDetailID)
            {
                return BadRequest();
            }

            _context.Entry(eventDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventDetailExists(id))
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

        // POST: api/EventDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EventDetail>> PostEventDetail(EventDetail eventDetail)
        {
            var list = _context.EventDetails.ToList();
            eventDetail.EventDetailID = list.Any() ? list.Count() + 1 : 1;
            _context.EventDetails.Add(eventDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/EventDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventDetail>> DeleteEventDetail(int id)
        {
            var eventDetail = await _context.EventDetails.FindAsync(id);
            if (eventDetail == null)
            {
                return NotFound();
            }

            _context.EventDetails.Remove(eventDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventDetailExists(int id)
        {
            return _context.EventDetails.Any(e => e.EventDetailID == id);
        }
    }
}
