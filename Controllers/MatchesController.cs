using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CricMazaAPISerDb.Models;

namespace CricMazaAPISerDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly CricMaza21Context _context;

        public MatchesController(CricMaza21Context context)
        {
            _context = context;
        }

        // GET: api/Matches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matches>>> GetMatches()
        {
            return await _context.Matches.ToListAsync();
        }

        // GET: api/Matches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Matches>> GetMatches(int id)
        {
            var matches = await _context.Matches.FindAsync(id);

            if (matches == null)
            {
                return NotFound();
            }

            return matches;
        }

        // PUT: api/Matches/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatches(int id, Matches matches)
        {
            if (id != matches.Mid)
            {
                return BadRequest();
            }

            _context.Entry(matches).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchesExists(id))
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

        // POST: api/Matches
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Matches>> PostMatches(Matches matches)
        {
            _context.Matches.Add(matches);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MatchesExists(matches.Mid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMatches", new { id = matches.Mid }, matches);
        }

        // DELETE: api/Matches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Matches>> DeleteMatches(int id)
        {
            var matches = await _context.Matches.FindAsync(id);
            if (matches == null)
            {
                return NotFound();
            }

            _context.Matches.Remove(matches);
            await _context.SaveChangesAsync();

            return matches;
        }

        private bool MatchesExists(int id)
        {
            return _context.Matches.Any(e => e.Mid == id);
        }
    }
}
