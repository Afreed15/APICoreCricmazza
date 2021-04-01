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
    public class PointsTablesController : ControllerBase
    {
        private readonly CricMaza21Context _context;

        public PointsTablesController(CricMaza21Context context)
        {
            _context = context;
        }

        // GET: api/PointsTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PointsTable>>> GetPointsTable()
        {
            return await _context.PointsTable.ToListAsync();
        }

        // GET: api/PointsTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PointsTable>> GetPointsTable(int id)
        {
            var pointsTable = await _context.PointsTable.FindAsync(id);

            if (pointsTable == null)
            {
                return NotFound();
            }

            return pointsTable;
        }

        // PUT: api/PointsTables/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPointsTable(int id, PointsTable pointsTable)
        {
            if (id != pointsTable.Ptid)
            {
                return BadRequest();
            }

            _context.Entry(pointsTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PointsTableExists(id))
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

        // POST: api/PointsTables
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PointsTable>> PostPointsTable(PointsTable pointsTable)
        {
            _context.PointsTable.Add(pointsTable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PointsTableExists(pointsTable.Ptid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPointsTable", new { id = pointsTable.Ptid }, pointsTable);
        }

        // DELETE: api/PointsTables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PointsTable>> DeletePointsTable(int id)
        {
            var pointsTable = await _context.PointsTable.FindAsync(id);
            if (pointsTable == null)
            {
                return NotFound();
            }

            _context.PointsTable.Remove(pointsTable);
            await _context.SaveChangesAsync();

            return pointsTable;
        }

        private bool PointsTableExists(int id)
        {
            return _context.PointsTable.Any(e => e.Ptid == id);
        }
    }
}
