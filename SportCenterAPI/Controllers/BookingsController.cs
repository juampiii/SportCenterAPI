using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportCenterAPI.Data;
using SportCenterAPI.Models;
using SportCenterAPI.Models.DTO;
using SportCenterAPI.Models.Manager;

namespace SportCenterAPI.Controllers
{
    /// <summary>
    /// Represents a Controller to manage the operations in the <see cref="Booking"/>.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingManager _manager;

        /// <summary>
        /// Create a new instance of the <see cref="BookingsController"/>
        /// </summary>
        /// <param name="manager">The manager for performing operations in the database</param>
        public BookingsController(IBookingManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Get the list of all Bookings from the Sport Center,
        /// </summary>
        /// <returns>The list of available <see cref="Booking"/></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [Produces("application/json", Type = typeof(IEnumerable<Booking>))]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            var elements = await _manager.GetAll();
            return Ok(elements);
        }

        /// <summary>
        /// Get the <see cref="Booking"/> whose ID matches with the one received 
        /// </summary>
        /// <param name="id">The id of the <see cref="Booking"/> to checks</param>
        /// <returns>The <see cref="Booking"/> whose ID matches with the one received </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var element = await _manager.Get(id);

            if (element == null)
            {
                return NotFound();
            }

            return Ok(element);
        }

        /// <summary>
        /// Updates an existing <see cref="Booking"/>
        /// </summary>
        /// <param name="id">The ID of the <see cref="Booking"/> to update</param>
        /// <param name="booking">The new values of the <see cref="Booking"/></param>
        /// <returns>The result of the operation</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PutBooking(int id, Booking booking)
        {
            if (id != booking.Id)
            {
                return BadRequest();
            }

            await _manager.Update(id, booking);

            return NoContent();
        }

        /// <summary>
        /// Remove a <see cref="Booking"/> from the Sport Center.
        /// </summary>
        /// <param name="id">The Id of the <see cref="Booking"/> to remove</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json", Type = typeof(Booking))]
        public async Task<ActionResult<Booking>> DeleteBooking(int id)
        {
            var element = await _manager.DeleteAsync(id);

            if (element == null)
            {
                return NotFound();
            }

            return element;
        }

        /// <summary>
        /// Add a new <see cref="Booking"/> for a <see cref="Member"/> at a specific time
        /// </summary>
        /// <param name="bookingRequest">A <see cref="BookingDTO"/> with the information about the request</param>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Booking))]
        [ProducesResponseType(400)]
        public ActionResult<Booking> PostBooking([FromBody] BookingDTO bookingRequest)
        {
            if (_manager.BookingExist(bookingRequest.CourtId, bookingRequest.BookingDate))
            {
                return BadRequest("The court is already booked");
            }

            if (!_manager.BookingMemberAllowed(bookingRequest.MemberId, bookingRequest.BookingDate))
            {
                return BadRequest("The Booking not allowed for this member");
            }

            var element = _manager.AddBookingMemberAsync(bookingRequest);


            return CreatedAtAction("GetBooking", new { id = element.Id }, element);
        }

        /// <summary>
        /// Get the list of all <see cref="Booking"/> from the Sport Center for an specific Date
        /// </summary>
        /// <returns>The list of available <see cref="Booking"/> for a Date</returns>
        [HttpGet("{dateTime:Datetime}")]
        [ProducesResponseType(200)]
        [Produces("application/json", Type = typeof(IEnumerable<Booking>))]
        public ActionResult<IEnumerable<Booking>> GetDailyBookings(DateTime dateTime)
        {
            return Ok(_manager.GetDailyBookings(dateTime));
        }        
    }
}
