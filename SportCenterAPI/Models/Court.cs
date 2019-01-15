using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportCenterAPI.Models
{
    /// <summary>
    /// Represents an Court from the Sport Center
    /// </summary>
    public class Court
    {
        /// <summary>
        /// The ID of the <see cref="Court"/>
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// The Name of the <see cref="Court"/>
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The <see cref="Sport"/> that can be practiced on the <see cref="Court"/>
        /// </summary>
        [ForeignKey("SportForeignKey")]
        public virtual Sport Sport { get; set; }
    }
}
