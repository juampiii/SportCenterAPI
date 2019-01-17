using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportCenterAPI.Models
{
    /// <summary>
    /// Represents a User from the Sport Center
    /// </summary>
    public class User
    {
        /// <summary>
        /// The ID of the <see cref="User"/>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Password of the <see cref="User"/>
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The Name of the <see cref="User"/>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Date when the user have been created
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
