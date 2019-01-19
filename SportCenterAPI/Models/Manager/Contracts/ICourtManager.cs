using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportCenterAPI.Models.Manager
{
    /// <summary>
    /// Describes basic operation of a manager used to perform diferent operations over the collection of <see cref="Court"/> in the Sport Center
    /// </summary>
    public interface ICourtManager : IManager<Court>
    {
        /// <summary>
        /// Return a List of available courts to practice a <see cref="Sport"/> in the retrieved dateTime
        /// </summary>
        /// <param name="sportId">The id of the <see cref="Sport"/></param>
        /// <param name="dateTime">The dateTime to checks if the court is booked</param>
        /// <returns>A list of available <see cref="Court"/></returns>
        IEnumerable<Court> FindAvailableCourtsBySport(int sportId, DateTime dateTime);
    }
}
