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
    public class PlayerProfilesController : ControllerBase
    {
        private readonly CricMaza21Context _context;

        public PlayerProfilesController(CricMaza21Context context)
        {
            _context = context;
        }

        // GET: api/PlayerProfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerProfile>>> GetPlayerProfile()
        {
            return await _context.PlayerProfile.ToListAsync();
        }

        // GET: api/PlayerProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerProfile>> GetPlayerProfile(int id)
        {
            var playerProfile = await _context.PlayerProfile.FindAsync(id);

            if (playerProfile == null)
            {
                return NotFound();
            }

            return playerProfile;
        }

        // PUT: api/PlayerProfiles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerProfile(int id, PlayerProfile playerProfile)
        {
            if (id != playerProfile.Profileid)
            {
                return BadRequest();
            }

            _context.Entry(playerProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerProfileExists(id))
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

        // POST: api/PlayerProfiles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PlayerProfile>> PostPlayerProfile(PlayerProfile playerProfile)
        {
            _context.PlayerProfile.Add(playerProfile);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlayerProfileExists(playerProfile.Profileid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlayerProfile", new { id = playerProfile.Profileid }, playerProfile);
        }

        // DELETE: api/PlayerProfiles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlayerProfile>> DeletePlayerProfile(int id)
        {
            var playerProfile = await _context.PlayerProfile.FindAsync(id);
            if (playerProfile == null)
            {
                return NotFound();
            }

            _context.PlayerProfile.Remove(playerProfile);
            await _context.SaveChangesAsync();

            return playerProfile;
        }

        private bool PlayerProfileExists(int id)
        {
            return _context.PlayerProfile.Any(e => e.Profileid == id);
        }
    }
}
