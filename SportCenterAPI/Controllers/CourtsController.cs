using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportCenterAPI.Data;
using SportCenterAPI.Models;
using SportCenterAPI.Models.DTO;
using SportCenterAPI.Models.Manager;

namespace SportCenterAPI.Controllers
{
    /// <summary>
    /// Represents a Controller to manage the operations in the <see cref="Court"/>.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CourtsController : ControllerBase
    {
        private readonly ICourtManager _manager;

        /// <summary>
        /// Create a new instance of the <see cref="CourtsController"/>
        /// </summary>
        /// <param name="manager">The manager for performing operations in the database</param>
        public CourtsController(ICourtManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Get the list of all Courts from the Sport Center,
        /// </summary>
        /// <returns>The list of available <see cref="Court"/></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [Produces("application/json", Type = typeof(IEnumerable<Court>))]
        public async Task<ActionResult<IEnumerable<Court>>> GetCourts()
        {
            var courts = await _manager.GetAll();
            return Ok(courts);
        }

        /// <summary>
        /// Get the <see cref="Court"/> whose ID matches with the one received 
        /// </summary>
        /// <param name="id">The id of the <see cref="Court"/> to checks</param>
        /// <returns>The <see cref="Court"/> whose ID matches with the one received </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json", Type = typeof(Court))]
        public async Task<ActionResult<Court>> GetCourt(int id)
        {
            var element = await _manager.Get(id);

            if (element == null)
            {
                return NotFound();
            }

            return Ok(element);
        }

        /// <summary>
        /// Updates an existing <see cref="Court"/>
        /// </summary>
        /// <param name="id">The ID of the <see cref="Court"/> to update</param>
        /// <param name="court">The new values of the <see cref="Court"/></param>
        /// <returns>The result of the operation</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PutCourt(int id, Court court)
        {
            if (id != court.Id)
            {
                return BadRequest();
            }

            await _manager.Update(id, court);

            return NoContent();
        }

        /// <summary>
        /// Add a new <see cref="Court"/>
        /// </summary>
        /// <param name="court">The Court to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Court))]
        public async Task<ActionResult<Court>> PostCourt(Court court)
        {
            var courtAdded = await _manager.Add(court);

            return CreatedAtAction("GetCourt", new { id = courtAdded.Id }, courtAdded);
        }

        /// <summary>
        /// Remove a <see cref="Court"/> from the Sport Center.
        /// </summary>
        /// <param name="id">The Id of the <see cref="Court"/> to remove</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json", Type = typeof(Court))]
        public async Task<ActionResult<Court>> DeleteCourt(int id)
        {
            var element = await _manager.DeleteAsync(id);

            if (element == null)
            {
                return NotFound();
            }

            return element;
        }

        /// <summary>
        /// Get a list of available <see cref="Court"/> to book.
        /// </summary>
        /// <param name="bookingRequest">A <see cref="BookingDTO"/> with the information about the request</param>
        /// <returns>A list of available <see cref="Court"/></returns>
        [HttpPost]
        [Route("Find")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json", Type = typeof(IEnumerable<Court>))]
        public ActionResult<IEnumerable<Court>> FindCourts([FromBody] BookingDTO bookingRequest)
        {
            IEnumerable<Court> courts = _manager.FindAvailableCourtsBySport(bookingRequest.SportId, bookingRequest.BookingDate);

            if (courts.Count() == 0)
            {
                return NotFound();
            }

            return Ok(courts);
        }        
    }
}
