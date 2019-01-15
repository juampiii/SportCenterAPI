using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportCenterAPI.Data;
using SportCenterAPI.Models;

namespace SportCenterAPI.Controllers
{
    /// <summary>
    /// Represents a Controller to manage the operations in the <see cref="Sport"/>.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SportsController : ControllerBase
    {
        private readonly SportCenterDBContext _context;

        /// <summary>
        /// Create a new instance of the <see cref="SportsController"/>
        /// </summary>
        /// <param name="context">The context for performing operations in the database</param>
        public SportsController(SportCenterDBContext context)
        {
            _context = context;
        }

        // GET: api/Sports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sport>>> GetSports()
        {
            return await _context.Sports.Include(c => c.Courts).ToListAsync();
        }

        // GET: api/Sports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sport>> GetSport(int id)
        {
            var sport = await _context.Sports.Include(c => c.Courts).FirstOrDefaultAsync(s => s.Id == id);

            if (sport == null)
            {
                return NotFound();
            }

            return Ok(sport);
        }

        // PUT: api/Sports/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSport(int id, Sport sport)
        {
            if (id != sport.Id)
            {
                return BadRequest();
            }

            _context.Entry(sport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SportExists(id))
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

        // POST: api/Sports
        [HttpPost]
        public async Task<ActionResult<Sport>> PostSport(Sport sport)
        {
            _context.Sports.Add(sport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSport", new { id = sport.Id }, sport);
        }

        // DELETE: api/Sports/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sport>> DeleteSport(int id)
        {
            var sport = await _context.Sports.FindAsync(id);
            if (sport == null)
            {
                return NotFound();
            }

            _context.Sports.Remove(sport);
            await _context.SaveChangesAsync();

            return sport;
        }

        private bool SportExists(int id)
        {
            return _context.Sports.Any(e => e.Id == id);
        }
    }
}
