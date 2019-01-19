using System;

namespace SportCenterAPI.Models
{
    /// <summary>
    /// Represents a reservation of a <see cref="Court"/> by a <see cref="Member"/> of the Sport Center
    /// </summary>
    public class Booking
    {
        /// <summary>
        /// The ID of the <see cref="Booking"/>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The id of the member who book the Court
        /// </summary>
        public int MemberForeignKey { get; set; }

        /// <summary>
        /// The id of the court booked by the member
        /// </summary>
        public int CourtForeignKey { get; set; }

        /// <summary>
        /// The date when the user made the booking
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// The date when the court is available to the member
        /// </summary>
        public DateTime BookingDate { get; set; }

        /// <summary>
        /// The member who book the court
        /// </summary>
        public virtual Member Member { get; set; }

        /// <summary>
        /// The court booked by the member
        /// </summary>
        public virtual Court Court { get; set; }
    }
}
