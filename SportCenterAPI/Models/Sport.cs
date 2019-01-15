using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportCenterAPI.Models
{
    /// <summary>
    /// Represents an Sport from the Sport Center
    /// </summary>
    public class Sport
    {
        /// <summary>
        /// The ID of the <see cref="Sport"/>
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// The Name of the <see cref="Sport"/>
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Collection of <see cref="Court"/> on which you can practice the <see cref="Sport"/>
        /// </summary>
        public virtual ICollection<Court> Courts { get; set; }
    }
}
