using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportCenterAPI.Models.Manager
{
    /// <summary>
    /// Describes basic operation of a manager used to perform diferent operations over the collection of <see cref="User"/> in the Sport Center
    /// </summary>
    public interface IUserManager : IManager<User>
    {
        /// <summary>
        /// Authenticate the <see cref="User"/> in the Sport Center API
        /// </summary>
        /// <param name="username">The name of the <see cref="User"/></param>
        /// <param name="password">The password of the <see cref="User"/></param>
        /// <returns>The <see cref="User"/> created</returns>
        Task<User> RegisterAsync(string username, string password);

        /// <summary>
        /// Authenticate the <see cref="User"/> in the Sport Center API
        /// </summary>
        /// <param name="username">The name of the <see cref="User"/></param>
        /// <param name="password">The password of the <see cref="User"/></param>
        /// <returns>The <see cref="User"/> authenticated</returns>
        Task<User> Authenticate(string username, string password);
    }
}
