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
    public class TournamentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TournamentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Tournaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Tournament>>> GetTournaments()
        {
            return await _context.Tournaments.ToListAsync();
        }

        // GET: api/Tournaments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Tournament>> GetTournament(int id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);

            if (tournament == null)
            {
                return NotFound();
            }

            return tournament;
        }

        // PUT: api/Tournaments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTournament(int id, Models.Tournament tournament)
        {
            if (id != tournament.TournamentID)
            {
                return BadRequest();
            }

            _context.Entry(tournament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TournamentExists(id))
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

        // POST: api/Tournaments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Models.Tournament>> PostTournament(Models.Tournament tournament)
        {
            var list = _context.Tournaments.ToList();
            tournament.TournamentID = list.Any() ? list.Count() + 1 : 1;
            _context.Tournaments.Add(tournament);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Tournaments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Tournament>> DeleteTournament(int id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }

            _context.Tournaments.Remove(tournament);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TournamentExists(int id)
        {
            return _context.Tournaments.Any(e => e.TournamentID == id);
        }
    }
}
