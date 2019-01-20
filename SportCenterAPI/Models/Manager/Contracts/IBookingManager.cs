using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportCenterAPI.Models.DTO;

namespace SportCenterAPI.Models.Manager
{
    /// <summary>
    /// Describes basic operation of a manager used to perform diferent operations over the collection of <see cref="Booking"/> in the Sport Center
    /// </summary>
    public interface IBookingManager : IManager<Booking>
    {
        /// <summary>
        /// Add a new <see cref="Booking"/> for a <see cref="Member"/> at a specific time
        /// </summary>
        /// <param name="bookingRequest">A <see cref="BookingDTO"/> with the information about the request</param>
        Task<Booking> AddBookingMemberAsync(BookingDTO bookingRequest);

        /// <summary>
        /// Get the list of all <see cref="Booking"/> from the Sport Center for an specific Date
        /// </summary>
        /// <returns>The list of available <see cref="Booking"/> for a Date</returns>
        IEnumerable<Booking> GetDailyBookings(DateTime dateTime);

        /// <summary>
        /// Checks if a <see cref="Court"/> have been booking in a dateTime
        /// </summary>
        /// <param name="courtId">The id of the <see cref="Court"/></param>
        /// <param name="dateTime">The dateTime to checks the availability</param>
        /// <returns></returns>
        bool BookingAlreadyExist(int courtId, DateTime dateTime);

        /// <summary>
        /// Checks if the <see cref="Member"/> is allowd to book a <see cref="Court"/> at a specific time
        /// </summary>
        /// <param name="memberId">The id of the <see cref="Member"/> who want to book a <see cref="Court"/></param>
        /// <param name="dateTime">the DateTime to perfor the booking</param>
        /// <returns></returns>
        bool BookingMemberAllowed(int memberId, DateTime dateTime);
    }
}
