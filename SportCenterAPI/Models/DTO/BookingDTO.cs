using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportCenterAPI.Models.DTO
{
    /// <summary>
    /// Represents a DTO with the information of a <see cref="Booking"/> request
    /// </summary>
    public class BookingDTO
    {

        /// <summary>
        /// The id of the member who request to book a Court
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// The id of the court requested
        /// </summary>
        public int CourtId { get; set; }

        /// <summary>
        /// The id of the sport requested
        /// </summary>
        public int SportId { get; set; }

        /// <summary>
        /// The date when the court is available to the member
        /// </summary>
        public DateTime BookingDate { get; set; }
    }
}
