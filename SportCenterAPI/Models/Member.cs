using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SportCenterAPI.Models
{
    /// <summary>
    /// Represents a user who is member from the Sport Center
    /// </summary>
    public class Member : User
    {
        /// <summary>
        /// The phone number of the <see cref="Member"/>
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// The list of booking from the user
        /// </summary>
        public virtual ICollection<Booking> Bookings { get; set; }

        /// <summary>
        /// Create a new instance of the <see cref="Member"/>
        /// </summary>
        public Member()
        {
            Bookings = new Collection<Booking>();
        }
    }
}
