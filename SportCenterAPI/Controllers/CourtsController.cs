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
    /// Represents a Controller to manage the operations in the <see cref="Court"/>.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CourtsController : ControllerBase
    {
        private readonly SportCenterDBContext _context;

        /// <summary>
        /// Create a new instance of the <see cref="CourtsController"/>
        /// </summary>
        /// <param name="context">The context for performing operations in the database</param>
        public CourtsController(SportCenterDBContext context)
        {
            _context = context;
        }

        // GET: api/Courts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Court>>> GetCourts()
        {
            return await _context.Courts.Include(s => s.Sport).ToListAsync();
        }

        // GET: api/Courts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Court>> GetCourt(int id)
        {
            var court = await _context.Courts.Include(s => s.Sport).FirstOrDefaultAsync(c => c.Id == id);

            if (court == null)
            {
                return NotFound();
            }

            return Ok(court);
        }

        // PUT: api/Courts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourt(int id, Court court)
        {
            if (id != court.Id)
            {
                return BadRequest();
            }

            _context.Entry(court).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourtExists(id))
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

        // POST: api/Courts
        [HttpPost]
        public async Task<ActionResult<Court>> PostCourt(Court court)
        {
            _context.Courts.Add(court);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourt", new { id = court.Id }, court);
        }

        // DELETE: api/Courts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Court>> DeleteCourt(int id)
        {
            var court = await _context.Courts.FindAsync(id);
            if (court == null)
            {
                return NotFound();
            }

            _context.Courts.Remove(court);
            await _context.SaveChangesAsync();

            return court;
        }

        private bool CourtExists(int id)
        {
            return _context.Courts.Any(e => e.Id == id);
        }
    }
}
