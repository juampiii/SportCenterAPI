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
    /// Represents a Controller to manage the operations in the <see cref="Member"/>.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberManager _manager;

        /// <summary>
        /// Create a new instance of the <see cref="MembersController"/>
        /// </summary>
        /// <param name="context">The manager for performing operations in the database</param>
        public MembersController(IMemberManager context)
        {
            _manager = context;
        }

        /// <summary>
        /// Get the list of all Members from the Sport Center,
        /// </summary>
        /// <returns>The list of available <see cref="Member"/></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [Produces("application/json", Type = typeof(IEnumerable<Member>))]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            var element = await _manager.GetAll();

            if (element == null)
            {
                return NotFound();
            }

            return Ok(element);
        }

        /// <summary>
        /// Get the <see cref="Member"/> whose ID matches with the one received 
        /// </summary>
        /// <param name="id">The id of the <see cref="Member"/> to checks</param>
        /// <returns>The <see cref="Member"/> whose ID matches with the one received </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Member>> GetMember(int id)
        {
            var element = await _manager.Get(id);

            if (element == null)
            {
                return NotFound();
            }

            return Ok(element);
        }

        /// <summary>
        /// Updates an existing <see cref="Member"/>
        /// </summary>
        /// <param name="id">The ID of the <see cref="Member"/> to update</param>
        /// <param name="member">The new values of the <see cref="Member"/></param>
        /// <returns>The result of the operation</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PutMember(int id, Member member)
        {

            if (id != member.Id)
            {
                return BadRequest();
            }

            await _manager.Update(id, member);

            return NoContent();
        }

        /// <summary>
        /// Add a new <see cref="Member"/>
        /// </summary>
        /// <param name="member">The Member to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Member))]
        public async Task<ActionResult<Member>> PostMember(Member member)
        {
            var memberAdded = await _manager.Add(member);


            return CreatedAtAction("GetMember", new { id = memberAdded.Id }, memberAdded);
        }

        /// <summary>
        /// Remove a <see cref="Member"/> from the Sport Center.
        /// </summary>
        /// <param name="id">The Id of the <see cref="Member"/> to remove</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json", Type = typeof(Member))]
        public async Task<ActionResult<Member>> DeleteMember(int id)
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
