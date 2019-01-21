using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SportCenterAPI.Models
{
    /// <summary>
    /// Represents a member from the Sport Center
    /// </summary>
    public class Member
    {
        /// <summary>
        /// The ID of the <see cref="Member"/>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Name of the <see cref="Member"/>
        /// </summary>
        public string Name { get; set; }

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
