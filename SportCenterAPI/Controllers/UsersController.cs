using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportCenterAPI.Data;
using SportCenterAPI.Models;
using SportCenterAPI.Models.Manager;

namespace SportCenterAPI.Controllers
{
    /// <summary>
    /// Represents a Controller to manage the operations in the <see cref="User"/>.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _manager;

        /// <summary>
        /// Create a new instance of the <see cref="UsersController"/>
        /// </summary>
        /// <param name="manager">The manager for performing operations in the database</param>
        public UsersController(IUserManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Get the list of all Users from the Sport Center,
        /// </summary>
        /// <returns>The list of available <see cref="User"/></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [Produces("application/json", Type = typeof(IEnumerable<User>))]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var elements = await _manager.GetAll();
            return Ok(elements);
        }

        /// <summary>
        /// Get the <see cref="User"/> whose ID matches with the one received 
        /// </summary>
        /// <param name="id">The id of the <see cref="User"/> to checks</param>
        /// <returns>The <see cref="User"/> whose ID matches with the one received </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var element = await _manager.Get(id);

            if (element == null)
            {
                return NotFound();
            }

            return Ok(element);
        }

        /// <summary>
        /// Updates an existing <see cref="User"/>
        /// </summary>
        /// <param name="id">The ID of the <see cref="User"/> to update</param>
        /// <param name="user">The new values of the <see cref="User"/></param>
        /// <returns>The result of the operation</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await _manager.Update(id, user);

            return NoContent();
        }

        /// <summary>
        /// Add a new <see cref="User"/>
        /// </summary>
        /// <param name="user">The User to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(User))]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var userAdded = await _manager.Add(user);

            return CreatedAtAction("GetSport", new { id = userAdded.Id }, userAdded);
        }

        /// <summary>
        /// Remove a <see cref="User"/> from the Sport Center.
        /// </summary>
        /// <param name="id">The Id of the <see cref="User"/> to remove</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json", Type = typeof(User))]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var element = await _manager.DeleteAsync(id);

            if (element == null)
            {
                return NotFound();
            }

            return element;
        }
    }
}
