using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportCenterAPI.Data;
using SportCenterAPI.Models;
using SportCenterAPI.Models.Manager;

namespace SportCenterAPI.Controllers
{
    /// <summary>
    /// Represents a Controller to manage the operations in the <see cref="Sport"/>.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SportsController : ControllerBase
    {
        private readonly ISportManager _manager;

        /// <summary>
        /// Create a new instance of the <see cref="SportsController"/>
        /// </summary>
        /// <param name="manager">The manager for performing operations in the data</param>
        public SportsController(ISportManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Get the list of all Sports from the Sport Center,
        /// </summary>
        /// <returns>The list of available <see cref="Sport"/></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [Produces("application/json", Type = typeof(IEnumerable<Sport>))]
        public async Task<ActionResult<IEnumerable<Sport>>> GetSports()
        {
            var sports = await _manager.GetAll();
            return Ok(sports);
        }

        /// <summary>
        /// Get the <see cref="Sport"/> whose ID matches with the one received 
        /// </summary>
        /// <param name="id">The id of the <see cref="Sport"/> to checks</param>
        /// <returns>The <see cref="Sport"/> whose ID matches with the one received </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json", Type = typeof(Sport))]
        public async Task<ActionResult<Sport>> GetSport(int id)
        {
            var sport = await _manager.Get(id);

            if (sport == null)
            {
                return NotFound();
            }

            return Ok(sport);
        }

        /// <summary>
        /// Updates an existing <see cref="Sport"/>
        /// </summary>
        /// <param name="id">The ID of the <see cref="Sport"/> to update</param>
        /// <param name="sport">The new values of the <see cref="Sport"/></param>
        /// <returns>The result of the operation</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PutSport(int id, Sport sport)
        {
            if (id != sport.Id)
            {
                return BadRequest();
            }

            await _manager.Update(id, sport);

            return NoContent();
        }

        /// <summary>
        /// Add a new <see cref="Sport"/>
        /// </summary>
        /// <param name="sport">The Sport to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Sport))]
        public async Task<ActionResult<Sport>> PostSport(Sport sport)
        {
            var sportAdded = await _manager.Add(sport);

            return CreatedAtAction("GetSport", new { id = sportAdded.Id }, sportAdded);
        }

        /// <summary>
        /// Remove a <see cref="Sport"/> from the Sport Center.
        /// </summary>
        /// <param name="id">The Id of the <see cref="Sport"/> to remove</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json", Type = typeof(Sport))]
        public async Task<ActionResult<Sport>> DeleteSport(int id)
        {
            var element = await _manager.DeleteAsync(id);

            if (element == null)
            {
                return NotFound();
            }

            return Ok(element);
        }
    }
}
